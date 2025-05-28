using Common.Components;
using Features.Enemy.Components;
using Infrastructure;
using Infrastructure.Registrars;
using Tags.GroundCheck;
using UnityEngine;
using Views.Components;
using Voody.UniLeo.Lite;

namespace Features.Enemy.Services
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _prefab;
        [SerializeField] private Transform _spawnPoint;

        public void SpawnEnemy()
        {
            int entityId = WorldHandler.GetMainWorld().NewEntity();

            PoolWorker.AddComponent<PlayerDirectionTag>(entityId);
            PoolWorker.AddComponent<GroundCheckTag>(entityId);
            PoolWorker.AddComponent<ViewPrefab>(entityId).Value = _prefab;
            PoolWorker.AddComponent<SpawnPositionComponent>(entityId).Value = _spawnPoint.position;
        }
    }
}