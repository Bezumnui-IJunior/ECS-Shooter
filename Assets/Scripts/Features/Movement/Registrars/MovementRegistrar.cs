using Common.Components;
using Features.Enemy.Components;
using Features.Movement.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Features.Movement.Registrars
{
    public class MovementRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;

        public override void RegisterComponents()
        {
            AddToPool<CharacterControllerComponent>().Value = _characterController;
            AddToPool<SpeedComponent>().Value = _speed;
            AddToPool<MoveDirectionComponent>();
            AddToPool<VelocityComponent>();
        }
        public override void UnregisterComponents()
        {
            DeleteFromPool<CharacterControllerComponent>();
            DeleteFromPool<MoveDirectionComponent>();
            DeleteFromPool<BodyTransformComponent>();
            DeleteFromPool<VelocityComponent>();
            DeleteFromPool<SpeedComponent>();
        }
    }
}