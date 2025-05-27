using Features.Player.Look.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Features.Player.Look.Registrars
{
    public class LookRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _sensitivity;

        public override void RegisterComponents()
        {
            AddToPool<BodyTransformComponent>().Value = _bodyTransform;
            AddToPool<CameraTransformComponent>().Value = _cameraTransform;
            AddToPool<CameraSensitivityComponent>().Value = _sensitivity;

            AddToPool<BodyAnglesComponent>();
            AddToPool<CameraAnglesComponent>();
        }

        public override void UnregisterComponents()
        {
            RemoveFromPool<BodyTransformComponent>();
            RemoveFromPool<CameraTransformComponent>();
            RemoveFromPool<CameraSensitivityComponent>();

            RemoveFromPool<BodyAnglesComponent>();
            RemoveFromPool<CameraAnglesComponent>();
        }
    }
}