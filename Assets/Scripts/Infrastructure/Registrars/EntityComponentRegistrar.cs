using Leopotam.EcsLite;
using Voody.UniLeo.Lite;

namespace Infrastructure.Registrars
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();

        protected ref T AddToPool<T>() where T : struct =>
            ref PoolWorker.AddComponent<T>(EntityId);

        protected void DeleteFromPool<T>() where T : struct
        {
            EcsPool<T> pool = WorldHandler.GetMainWorld().GetPool<T>();

            if (pool.Has(EntityId))
                pool.Del(EntityId);
        }
    }
}