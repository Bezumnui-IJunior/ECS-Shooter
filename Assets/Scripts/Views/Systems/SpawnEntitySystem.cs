using Data;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Views.Components;
using Views.Services;

namespace Views.Systems
{
    public class SpawnEntitySystem : SystemIterator, IEcsInitSystem
    {
        private readonly EntityViewFactory _entityViewFactory = new EntityViewFactory();
            
        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<ViewPrefab>()
                .Exc<ViewComponent>()
                .End()
            );
        }
        protected override void RunEntity()
        {
            _entityViewFactory.InstantiateEntity(GetEntityComponent<ViewPrefab>().Value, CurrentEntity);
        }

    }
}