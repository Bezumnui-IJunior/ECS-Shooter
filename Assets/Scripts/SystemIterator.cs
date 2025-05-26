using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

public abstract class SystemIterator : IEcsRunSystem
{
    private int _currentEntity;
    private EcsFilter _filter;

    public void Run(IEcsSystems systems)
    {
        foreach (int entity in _filter)
        {
            _currentEntity = entity;
            RunEntity();
        }
    }

    protected void SetFilter(EcsFilter filter) =>
        _filter = filter;

    protected ref T GetEntityComponent<T>(EcsPoolInject<T> pool) where T : struct =>
        ref pool.Value.Get(_currentEntity);

    protected void DeleteEntityComponent<T>(EcsPoolInject<T> pool) where T : struct =>
        pool.Value.Del(_currentEntity);

    protected bool HasEntityComponent<T>(EcsPoolInject<T> pool) where T : struct =>
        pool.Value.Has(_currentEntity);

    protected T AddEntityComponent<T>(EcsPoolInject<T> pool) where T : struct =>
        pool.Value.Add(_currentEntity);

    protected abstract void RunEntity();
}