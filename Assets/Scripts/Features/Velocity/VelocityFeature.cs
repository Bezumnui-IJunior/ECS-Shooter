using Features.Velocity.Systems;
using Leopotam.EcsLite;

namespace Features.Velocity
{
    public class VelocityFeature : IEcsSystem
    {
        public VelocityFeature(IEcsSystems systems)
        {
            systems.Add(new VelocitySystem());
        }
    }
}