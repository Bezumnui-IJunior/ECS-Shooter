using Features.Gravity.Components;
using Features.Movement.Components;
using Features.Velocity.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Tags.GroundCheck;
using UnityEngine;

namespace Features.Gravity.Systems
{
    public class GravitySystem : SystemIterator, IEcsInitSystem
    {
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

            if (HasEntityComponent<GroundedTag>() == false)
                velocity.y -= gravity * Time.deltaTime;
            else
                velocity.y = -1;
        }
    }
}