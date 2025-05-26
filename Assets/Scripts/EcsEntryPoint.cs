using System;
using Features.Gravity;
using Features.GroundCheck;
using Features.Input;
using Features.Jump;
using Features.Look;
using Features.Movement;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Views.InputSystem;
using Voody.UniLeo.Lite;

public class EcsEntryPoint : MonoBehaviour
{
    private InputSystem _inputSystem;

    private EcsSystems _systems;

    private EcsWorld _world;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddSystems();
        AddInjections();
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
        _systems = null;
        _world = null;
    }

    private void AddSystems()
    {
        _systems
            .Add(new PlayerInputSystem())
            .Add(new MovementSystem())
            .Add(new JumpSystem())
            .Add(new GravitySystem())
            .Add(new GroundedSetSystem())
            .Add(new GroundedRemoveSystem())
            .Add(new PlayerLookSystem());

#if UNITY_EDITOR
        _systems.Add(new EcsWorldDebugSystem());
#endif
    }

    private void AddInjections()
    {
        _systems.Inject(_inputSystem);
        // _systems.Inject();
    }
}