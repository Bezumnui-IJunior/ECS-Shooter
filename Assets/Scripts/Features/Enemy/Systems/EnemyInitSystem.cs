using Data;
using Features.Enemy.Services;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Features.Enemy.Systems
{
    public class EnemyInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData;

        public void Init(IEcsSystems systems)
        {
            _sceneData.Value.EnemyFactory.SpawnEnemy();
        }
    }
}