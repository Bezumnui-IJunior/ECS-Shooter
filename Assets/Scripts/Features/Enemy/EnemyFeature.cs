using Features.Enemy.Systems;
using Leopotam.EcsLite;

namespace Features.Enemy
{
    public class EnemyFeature : IEcsSystem
    {
        public EnemyFeature(IEcsSystems systems)
        {
            systems.Add(new EnemyInitSystem());
            systems.Add(new PlayerSetDirectionSystem());
        }
    }
}