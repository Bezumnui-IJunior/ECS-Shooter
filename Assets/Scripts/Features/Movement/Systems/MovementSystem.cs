using Common.Components;
using Features.Enemy.Components;
using Features.Movement.Components;
using Features.Velocity.Components;
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
                .Inc<BodyTransformComponent>()
                .Inc<MoveDirectionComponent>()
                .Inc<VelocityComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref float speed = ref GetEntityComponent<SpeedComponent>().Value;
            ref Transform transform = ref GetEntityComponent<BodyTransformComponent>().Value;
            ref Vector3 forward = ref GetEntityComponent<MoveDirectionComponent>().Value;
            ref Vector3 velocity = ref GetEntityComponent<VelocityComponent>().Value;

            Vector3 velocityXZ = (transform.right * forward.x + transform.forward * forward.z) * speed;
            velocity.x = velocityXZ.x;
            velocity.z = velocityXZ.z;
        }
    }
}