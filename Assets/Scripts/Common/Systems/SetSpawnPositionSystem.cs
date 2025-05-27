using Common.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Views.Components;

namespace Common.Systems
{
    public class SetSpawnPositionSystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsPoolInject<ViewComponent> _view;
        
        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<SpawnPositionComponent>()
                .Inc<ViewComponent>()
                .End()
            );
        }
        protected override void RunEntity()
        {
            GetEntityComponent<ViewComponent>().Value.gameObject.transform.position = GetEntityComponent<SpawnPositionComponent>().Value;
            DeleteEntityComponent<SpawnPositionComponent>();
        }

    }
}