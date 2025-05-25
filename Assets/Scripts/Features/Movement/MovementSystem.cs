using System;
using Features.Movement.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Features.Movement
{
    public sealed class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsPool<SpeedComponent> _speed = null;
        private readonly EcsPool<MoveableComponent> _moveable = null;
        private readonly EcsPool<TransformComponent> _transform = null;
        private readonly EcsPool<DirectionComponent> _direction = null;
        
        private EcsFilter _filter;


        public void Init(IEcsSystems systems)
        {
            _filter = systems.GetWorld()
                .Filter<SpeedComponent>()
                .Inc<MoveableComponent>()
                .Inc<TransformComponent>()
                .Inc<DirectionComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
                Move(entity);
        }

        private void Move(int entity)
        {
            ref float speed = ref _speed.Get(entity).Value;
            ref CharacterController controller = ref _moveable.Get(entity).Value;
            ref Transform transform = ref _transform.Get(entity).Value;
            ref Vector3 direction = ref _direction.Get(entity).Value;

            controller.Move((transform.right * direction.x + transform.forward * direction.z) * speed);
        }
    }
}