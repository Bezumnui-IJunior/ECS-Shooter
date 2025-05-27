using Input.Systems;
using Leopotam.EcsLite;

namespace Features.Input
{
    public class InputFeature : IEcsSystem
    {
        public InputFeature(IEcsSystems systems)
        {
            systems.Add(new PlayerInputMovementSystem());
        }
    }
}