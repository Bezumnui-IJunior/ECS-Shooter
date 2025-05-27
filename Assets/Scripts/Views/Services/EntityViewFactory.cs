using Infrastructure.Registrars;
using UnityEngine;

namespace Views.Services
{
    public class EntityViewFactory : MonoBehaviour
    {
        public void InstantiateEntity(EntityBehaviour prefab, int entityId)
        {
            EntityBehaviour obj = Instantiate(prefab);
            obj.Construct(entityId);
        }
    }
}