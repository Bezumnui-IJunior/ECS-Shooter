using Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Features.Player.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData = default;
        
        public void Init(IEcsSystems systems)
        {
            _sceneData.Value.PlayerFactory.CreatePlayer();
        }
    }
}