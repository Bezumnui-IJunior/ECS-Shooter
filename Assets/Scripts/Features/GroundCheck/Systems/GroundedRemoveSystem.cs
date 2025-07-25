using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags.GroundCheck;

namespace Features.GroundCheck.Systems
{
    public class GroundedRemoveSystem : SystemIterator, IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<GroundCheckTag>()
                .Inc<CharacterControllerComponent>()
                .Inc<GroundedTag>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            if (GetEntityComponent<CharacterControllerComponent>().Value.isGrounded == false)
                DeleteEntityComponent<GroundedTag>();
        }
    }
}