using Common.Components;
using Features.Player.Look.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Features.Player.Look.Registrars
{
    public class LookRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _sensitivity;

        public override void RegisterComponents()
        {
            AddToPool<CameraTransformComponent>().Value = _cameraTransform;
            AddToPool<CameraSensitivityComponent>().Value = _sensitivity;

            AddToPool<BodyAnglesComponent>();
            AddToPool<CameraAnglesComponent>();
        }

        public override void UnregisterComponents()
        {
            DeleteFromPool<CameraTransformComponent>();
            DeleteFromPool<CameraSensitivityComponent>();

            DeleteFromPool<BodyAnglesComponent>();
            DeleteFromPool<CameraAnglesComponent>();
        }
    }
}