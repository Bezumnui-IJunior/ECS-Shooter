using UnityEngine;

namespace Infrastructure.Registrars
{
    public interface IEntityBehaviour
    {
        int EntityId { get; }
        // ReSharper disable once InconsistentNaming
        GameObject gameObject { get; }
        void Construct(int entityId);
        void ReleaseEntity();
    }
}