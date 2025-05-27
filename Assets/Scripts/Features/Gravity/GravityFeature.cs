using Features.Gravity.Systems;
using Leopotam.EcsLite;

namespace Features.Gravity
{
    public class GravityFeature : IEcsSystem
    {
        public GravityFeature(IEcsSystems systems)
        {
            systems.Add(new GravitySystem());
        }
    }
}