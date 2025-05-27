using Common.Systems;
using Leopotam.EcsLite;

namespace Common
{
    public class CommonFeature : IEcsSystem
    {
        public CommonFeature(IEcsSystems systems)
        {
            systems.Add(new SetSpawnPositionSystem());
        }
    }
}