using Features.Jump.Events;
using Features.Movement.Components;
using Features.Velocity.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Tags.GroundCheck;
using UnityEngine;

namespace Features.Movement.Systems
{
    public class JumpSystem : SystemIterator, IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            SetFilter(
                systems.GetWorld()
                    .Filter<JumpEvent>()
                    .Inc<VelocityComponent>()
                    .Inc<JumpForceComponent>()
                    .Inc<GroundCheckTag>()
                    .End()
            );
        }

        protected override void RunEntity()
        {
            DeleteEntityComponent<JumpEvent>();

            ref Vector3 velocity = ref GetEntityComponent<VelocityComponent>().Value;
            ref float force = ref GetEntityComponent<JumpForceComponent>().Value;

            if (HasEntityComponent<GroundedTag>() == false)
                return;

            velocity.y = force;
        }
    }
}