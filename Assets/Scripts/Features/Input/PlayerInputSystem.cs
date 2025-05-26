using Features.Jump.Events;
using Features.Movement.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags;
using UnityEngine;

namespace Features.Input
{
    public sealed class PlayerInputSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<MoveDirectionComponent> _directionPool = default;
        private readonly EcsPoolInject<JumpEvent> _jumpEvent = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<PlayerTag>()
                .Inc<MoveDirectionComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref Vector3 moveDirection = ref GetEntityComponent(_directionPool).Value;
            moveDirection.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            moveDirection.z = UnityEngine.Input.GetAxisRaw("Vertical");

            if (UnityEngine.Input.GetButtonDown("Jump"))
                AddEntityComponent(_jumpEvent);
        }
    }
}