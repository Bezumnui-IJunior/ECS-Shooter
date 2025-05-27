using Features.Movement.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Registrars
{
    public class MovementRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;

        public override void RegisterComponents()
        {
            AddToPool<CharacterControllerComponent>().Value = _characterController;
            AddToPool<TransformComponent>().Value = _transform;
            AddToPool<SpeedComponent>().Value = _speed;
            AddToPool<MoveDirectionComponent>();
            AddToPool<VelocityComponent>();
        }
        public override void UnregisterComponents()
        {
            RemoveFromPool<CharacterControllerComponent>();
            RemoveFromPool<MoveDirectionComponent>();
            RemoveFromPool<TransformComponent>();
            RemoveFromPool<VelocityComponent>();
            RemoveFromPool<SpeedComponent>();
        }
    }
}