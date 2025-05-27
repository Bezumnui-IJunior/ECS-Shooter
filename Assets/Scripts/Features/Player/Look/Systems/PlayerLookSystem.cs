using Features.Player.Look.Components;
using Infrastructure;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Views.InputSystem;

namespace Features.Player.Look.Systems
{
    public class PlayerLookSystem : SystemIterator, IEcsInitSystem
    {
        private const float MinX = -80;
        private const float MaxX = 80;

        private readonly EcsCustomInject<InputSystem> _inputSystem = default;

        public void Init(IEcsSystems systems)
        {
            SetFilter(systems.GetWorld()
                .Filter<CameraSensitivityComponent>()
                .Inc<BodyTransformComponent>()
                .Inc<CameraTransformComponent>()
                .Inc<CameraAnglesComponent>()
                .Inc<BodyAnglesComponent>()
                .End()
            );
        }

        protected override void RunEntity()
        {
            ref Transform bodyTransform = ref GetEntityComponent<BodyTransformComponent>().Value;
            ref Transform cameraTransform = ref GetEntityComponent<CameraTransformComponent>().Value;
            ref Vector3 cameraAngles = ref GetEntityComponent<CameraAnglesComponent>().Value;
            ref Vector3 bodyAngles = ref GetEntityComponent<BodyAnglesComponent>().Value;
            ref float sensitivity = ref GetEntityComponent<CameraSensitivityComponent>().Value;
            InputSystem inputSystem = _inputSystem.Value;

            Vector2 input = inputSystem.PlayerMovement.Look.ReadValue<Vector2>();

            cameraAngles += Vector3.right * (-input.y * sensitivity);

            if (cameraAngles.x > MaxX)
                cameraAngles.x = MaxX;

            else if (cameraAngles.x < MinX)
                cameraAngles.x = MinX;

            bodyAngles += Vector3.up * (input.x * sensitivity);
            bodyAngles.y %= 360;

            cameraTransform.localRotation = Quaternion.Euler(cameraAngles);
            bodyTransform.localRotation = Quaternion.Euler(bodyAngles);
        }
    }
}