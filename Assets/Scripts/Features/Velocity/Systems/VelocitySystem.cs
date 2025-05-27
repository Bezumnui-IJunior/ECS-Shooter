using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Features.Velocity.Systems
{
    public class VelocitySystem : SystemIterator, IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<VelocityComponent>()
                .Inc<CharacterControllerComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref CharacterController controller = ref GetEntityComponent<CharacterControllerComponent>().Value;
            ref Vector3 velocity = ref GetEntityComponent<VelocityComponent>().Value;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}