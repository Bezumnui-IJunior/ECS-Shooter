using System;
using Data;
using Features.Input;
using Features.Movement;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

public class EcsEntryPoint : MonoBehaviour
{
    [SerializeField] private SceneData _sceneData;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        AddInjections();
        AddSystems();

        _systems.Init();
    }

    

    private void Update()
    {
        _systems.Run();
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
            .Add(new MovementSystem());
    }
    
    private void AddInjections()
    {
        _systems
            .Inject(_sceneData);
    }

    public struct MovableComponent { }
}