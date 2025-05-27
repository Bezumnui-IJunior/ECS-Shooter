using Features.Gravity.Components;
using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags.GroundCheck;
using UnityEngine;

namespace Features.Gravity.Systems
{
    public class GravitySystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<GravityComponent> _gravity = default;
        private readonly EcsPoolInject<VelocityComponent> _velocity = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<GravityComponent>()
                .Inc<VelocityComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref float gravity = ref GetEntityComponent<GravityComponent>().Value;
            ref Vector3 velocity = ref GetEntityComponent<VelocityComponent>().Value;

            if (HasEntityComponent<GroundedTag>())
                velocity.y = 0;
            else
                velocity.y -= gravity * Time.deltaTime;
        }
    }
}