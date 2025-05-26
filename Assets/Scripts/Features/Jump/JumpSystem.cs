using Features.Jump.Components;
using Features.Jump.Events;
using Features.Movement.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags.GroundCheck;
using UnityEngine;

namespace Features.Jump
{
    public class JumpSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<GroundedTag> _groundedTag = default;
        private readonly EcsPoolInject<JumpEvent> _jumpEvent = default;
        private readonly EcsPoolInject<JumpForceComponent> _jumpForce = default;
        private readonly EcsPoolInject<VelocityComponent> _velocity = default;

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
            DeleteEntityComponent(_jumpEvent);

            ref Vector3 velocity = ref GetEntityComponent(_velocity).Value;
            ref float force = ref GetEntityComponent(_jumpForce).Value;

            if (HasEntityComponent(_groundedTag) == false)
                return;

            velocity.y = force;
        }
    }
}