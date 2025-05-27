using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Features.Movement.Systems
{
    public sealed class MovementSystem : SystemIterator, IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<SpeedComponent>()
                .Inc<CharacterControllerComponent>()
                .Inc<TransformComponent>()
                .Inc<MoveDirectionComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref float speed = ref GetEntityComponent<SpeedComponent>().Value;
            ref CharacterController controller = ref GetEntityComponent<CharacterControllerComponent>().Value;
            ref Transform transform = ref GetEntityComponent<TransformComponent>().Value;
            ref Vector3 direction = ref GetEntityComponent<MoveDirectionComponent>().Value;

            controller.Move((transform.right * direction.x + transform.forward * direction.z) * speed * Time.deltaTime);
        }
    }
}