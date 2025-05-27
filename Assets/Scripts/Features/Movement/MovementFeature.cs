using Features.Jump;
using Features.Movement.Systems;
using Leopotam.EcsLite;

namespace Features.Movement
{
    public class MovementFeature : IEcsSystem
    {
        public MovementFeature(IEcsSystems systems)
        {
            systems.Add(new MovementSystem());
            systems.Add(new JumpSystem());
        }
    }
}