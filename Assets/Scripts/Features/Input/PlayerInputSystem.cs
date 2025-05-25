using Features.Movement.Components;
using Leopotam.EcsLite;
using Tags;

namespace Features.Input
{
    public sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<DirectionComponent> _directionPool;

        public void Init(IEcsSystems systems)
        {
            _filter = systems.GetWorld().Filter<PlayerTag>().Inc<DirectionComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
                ChangeDirection(entity);
        }

        private void ChangeDirection(int entity)
        {
            ref DirectionComponent direction = ref _directionPool.Get(entity);
            direction.Value.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            direction.Value.y = UnityEngine.Input.GetAxisRaw("Vertical");
        }
    }
}