using Data;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Views.Components;

namespace Views.Systems
{
    public class SpawnEntitySystem : SystemIterator, IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData = default; 
            
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
            _sceneData.Value.EntityViewFactory.InstantiateEntity(GetEntityComponent<ViewPrefab>().Value, CurrentEntity);
        }

    }
}