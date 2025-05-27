using Features.Jump.Events;
using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags;
using UnityEngine;

namespace Input.Systems
{
    public sealed class PlayerInputMovementSystem : SystemIterator, IEcsInitSystem
    {


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
            ref Vector3 moveDirection = ref GetEntityComponent<MoveDirectionComponent>().Value;
            moveDirection.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            moveDirection.z = UnityEngine.Input.GetAxisRaw("Vertical");

            if (UnityEngine.Input.GetButtonDown("Jump"))
                AddEntityComponent<JumpEvent>();
        }
    }
}