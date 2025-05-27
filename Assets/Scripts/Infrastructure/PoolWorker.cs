using Voody.UniLeo.Lite;

namespace Infrastructure
{
    public static class PoolWorker
    {
        public static ref T AddComponent<T>(int entityId) where T : struct =>
            ref WorldHandler.GetMainWorld().GetPool<T>().Add(entityId);

        public static bool HasComponent<T>(int entityId) where T : struct =>
            WorldHandler.GetMainWorld().GetPool<T>().Has(entityId);

        public static void DeleteComponent<T>(int entityId) where T : struct =>
            WorldHandler.GetMainWorld().GetPool<T>().Del(entityId);
        
        public static ref T GetComponent<T>(int entityId) where T : struct =>
            ref WorldHandler.GetMainWorld().GetPool<T>().Get(entityId);
    }
}