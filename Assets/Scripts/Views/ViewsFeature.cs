using Leopotam.EcsLite;
using Views.Systems;

namespace Views
{
    public class ViewsFeature : IEcsSystem
    {
        public ViewsFeature(IEcsSystems systems)
        {
            systems.Add(new SpawnEntitySystem());
        }
    }
}