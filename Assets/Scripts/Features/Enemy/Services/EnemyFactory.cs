using Infrastructure.Registrars;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace Features.Enemy.Services
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _prefab;
        [SerializeField] private Vector3 _position;

        public void SpawnEnemy()
        {
            int entityId = WorldHandler.GetMainWorld().NewEntity();
        }
    }
}