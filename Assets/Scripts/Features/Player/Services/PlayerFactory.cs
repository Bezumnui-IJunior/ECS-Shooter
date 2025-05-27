using Common.Components;
using Features.Player.Look.Components;
using Infrastructure;
using Infrastructure.Registrars;
using Tags;
using Tags.GroundCheck;
using UnityEngine;
using Views.Components;
using Voody.UniLeo.Lite;

namespace Features.Player.Services
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _prefab;
        [SerializeField] private Vector3 _position;

        public void CreatePlayer()
        {
            int entityId = WorldHandler.GetMainWorld().NewEntity();

            PoolWorker.AddComponent<PlayerTag>(entityId);
            PoolWorker.AddComponent<GroundCheckTag>(entityId);

            PoolWorker.AddComponent<ViewPrefab>(entityId).Value = _prefab;
            PoolWorker.AddComponent<SpawnPositionComponent>(entityId).Value = _position;
        }
    }
}