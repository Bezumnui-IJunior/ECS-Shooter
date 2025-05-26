using Features.Gravity.Components;
using Features.Movement.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags.GroundCheck;
using UnityEngine;

namespace Features.Gravity
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
                .Exc<GroundedTag>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref float gravity = ref GetEntityComponent(_gravity).Value;
            ref Vector3 velocity = ref GetEntityComponent(_velocity).Value;

            velocity.y -= gravity * Time.deltaTime;
        }
    }
}