using Infrastructure.Registrars;
using UnityEngine;

namespace Views.Services
{
    public class EntityViewFactory
    {
        public void InstantiateEntity(EntityBehaviour prefab, int entityId)
        {
            EntityBehaviour obj = Object.Instantiate(prefab);
            obj.Construct(entityId);
        }
    }
}