using System;
using Leopotam.EcsLite;
using UnityEngine;
using Views.Components;
using Voody.UniLeo.Lite;

namespace Infrastructure.Registrars
{
    public class EntityBehaviour : MonoBehaviour, IEntityBehaviour
    {
        public int EntityId { get; private set; }

        private bool _isInit;

        public void Construct(int entityId)
        {
            if (_isInit)
                throw new Exception($"{nameof(EntityBehaviour)} already initialized.");

            _isInit = true;
            EntityId = entityId;
            
            PoolWorker.AddComponent<ViewComponent>(entityId).Value = this;

            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();
        }
        
        [ContextMenu("Delete Entity")]
        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents();

            
            EntityId = 0;
            Destroy(gameObject);
            WorldHandler.GetMainWorld().DelEntity(EntityId);
        }
    }
}