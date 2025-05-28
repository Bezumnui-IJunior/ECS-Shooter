using Common.Components;
using Features.Enemy.Components;
using Features.Movement.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Tags;
using UnityEngine;

namespace Features.Enemy.Systems
{
    public class PlayerSetDirectionSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<PlayerTag, BodyTransformComponent>> _playerFilter = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<PlayerDirectionTag>()
                .Inc<BodyTransformComponent>()
                .Inc<MoveDirectionComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            foreach (int playerId in _playerFilter.Value)
            {
                Vector3 entityPosition = GetEntityComponent<BodyTransformComponent>().Value.position;
                Vector3 playerPosition = PoolWorker.GetComponent<BodyTransformComponent>(playerId).Value.position;

                Vector3 direction = (playerPosition - entityPosition).normalized;

                GetEntityComponent<MoveDirectionComponent>().Value = direction;
            }
        }
    }
}