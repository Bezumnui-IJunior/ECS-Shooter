using Common;
using Data;
using Features.Enemy;
using Features.Gravity;
using Features.GroundCheck;
using Features.Input;
using Features.Movement;
using Features.Player;
using Features.Velocity;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Views;
using Views.InputSystem;
using Voody.UniLeo.Lite;

public class EcsEntryPoint : MonoBehaviour
{
    [SerializeField] private SceneData _sceneData;
    
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
            .Add(new InputFeature(_systems))
            .Add(new ViewsFeature(_systems))
            .Add(new PlayerFeature(_systems))
            .Add(new EnemyFeature(_systems))
            .Add(new GroundCheckFeature(_systems))
            .Add(new GravityFeature(_systems))
            .Add(new MovementFeature(_systems))
            .Add(new VelocityFeature(_systems))
            .Add(new CommonFeature(_systems));

#if UNITY_EDITOR
        _systems.Add(new EcsWorldDebugSystem());
#endif
    }

    private void AddInjections()
    {
        _systems
            .Inject(_inputSystem)
            .Inject(_sceneData);
    }
}