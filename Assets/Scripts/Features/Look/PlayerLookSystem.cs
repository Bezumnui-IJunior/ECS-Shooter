using Features.Look.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Views.InputSystem;

namespace Features.Look
{
    public class PlayerLookSystem : SystemIterator, IEcsInitSystem
    {
        private const float MinX = -80;
        private const float MaxX = 80;

        private readonly EcsPoolInject<BodyTransformComponent> _bodyTransform = default;
        private readonly EcsPoolInject<CameraSensitivityComponent> _cameraSensitivity = default;
        private readonly EcsPoolInject<CameraTransformComponent> _cameraTransform = default;
        private readonly EcsPoolInject<CameraAnglesComponent> _cameraAngles = default;
        private readonly EcsPoolInject<BodyAnglesComponent> _bodyAngles = default;
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
            ref Transform bodyTransform = ref GetEntityComponent(_bodyTransform).Value;
            ref Transform cameraTransform = ref GetEntityComponent(_cameraTransform).Value;
            ref Vector3 cameraAngles = ref GetEntityComponent(_cameraAngles).Value;
            ref Vector3 bodyAngles = ref GetEntityComponent(_bodyAngles).Value;
            ref float sensitivity = ref GetEntityComponent(_cameraSensitivity).Value;
            InputSystem inputSystem = _inputSystem.Value;

            Vector2 input = inputSystem.PlayerMovement.Look.ReadValue<Vector2>();

            cameraAngles += Vector3.right * (-input.y * sensitivity);

            if (cameraAngles.x > MaxX)
                cameraAngles.x = MaxX;

            else if (cameraAngles.x < MinX)
                cameraAngles.x = MinX;

            bodyAngles += Vector3.up * (input.x * sensitivity);

            cameraTransform.localRotation = Quaternion.Euler(cameraAngles);
            bodyTransform.localRotation = Quaternion.Euler(bodyAngles);
        }
    }
}