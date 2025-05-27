using Features.GroundCheck.Systems;
using Leopotam.EcsLite;

namespace Features.GroundCheck
{
    public class GroundCheckFeature : IEcsSystem
    {
        public GroundCheckFeature(IEcsSystems systems)
        {
            systems.Add(new GroundedRemoveSystem());
            systems.Add(new GroundedSetSystem());
        }
    }
}