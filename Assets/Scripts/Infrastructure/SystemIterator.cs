using Leopotam.EcsLite;

namespace Infrastructure
{
    public abstract class SystemIterator : IEcsRunSystem
    {
        protected int CurrentEntity { get; private set; }
        private EcsFilter _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                CurrentEntity = entity;
                RunEntity();
            }
        }

        protected void SetFilter(EcsFilter filter) =>
            _filter = filter;

        protected ref T GetEntityComponent<T>() where T : struct =>
            ref PoolWorker.GetComponent<T>(CurrentEntity);

        protected void DeleteEntityComponent<T>() where T : struct =>
            PoolWorker.DeleteComponent<T>(CurrentEntity);

        protected bool HasEntityComponent<T>() where T : struct =>
            PoolWorker.HasComponent<T>(CurrentEntity);

        protected ref T AddEntityComponent<T>() where T : struct =>
            ref PoolWorker.AddComponent<T>(CurrentEntity);

        protected abstract void RunEntity();
    }
}