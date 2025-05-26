using Features.Movement.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags.GroundCheck;

namespace Features.GroundCheck
{
    public class GroundedSetSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<CharacterControllerComponent> _characterController = default;
        private readonly EcsPoolInject<GroundedTag> _grounded = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<GroundCheckTag>()
                .Inc<CharacterControllerComponent>()
                .Exc<GroundedTag>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            if (GetEntityComponent(_characterController).Value.isGrounded)
                AddEntityComponent(_grounded);
        }
    }
}