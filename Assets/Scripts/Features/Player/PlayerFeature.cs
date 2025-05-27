using Features.Player.Look.Systems;
using Features.Player.Systems;
using Leopotam.EcsLite;

namespace Features.Player
{
    public class PlayerFeature : IEcsSystem
    {
        public PlayerFeature(EcsSystems systems)
        {
            systems.Add(new PlayerInitSystem());
            systems.Add(new PlayerLookSystem());
        }
    }
}