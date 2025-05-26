using Features.Movement.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Features.Movement
{
    public sealed class MovementSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<MoveDirectionComponent> _direction = default;
        private readonly EcsPoolInject<CharacterControllerComponent> _moveable = default;
        private readonly EcsPoolInject<SpeedComponent> _speed = default;
        private readonly EcsPoolInject<TransformComponent> _transform = default;
        private readonly EcsPoolInject<VelocityComponent> _velocity = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<SpeedComponent>()
                .Inc<CharacterControllerComponent>()
                .Inc<TransformComponent>()
                .Inc<MoveDirectionComponent>()
                .Inc<VelocityComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref float speed = ref GetEntityComponent(_speed).Value;
            ref CharacterController controller = ref GetEntityComponent(_moveable).Value;
            ref Transform transform = ref GetEntityComponent(_transform).Value;
            ref Vector3 direction = ref GetEntityComponent(_direction).Value;
            ref Vector3 velocity = ref GetEntityComponent(_velocity).Value;

            controller.Move((transform.right * direction.x + transform.forward * direction.z) * speed * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);
        }
    }
}