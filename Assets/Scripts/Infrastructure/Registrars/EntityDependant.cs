using Infrastructure.Registrars;
using UnityEngine;

namespace Infrastructure
{
    public class EntityDependant : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _entityBehaviour;

        protected int EntityId => _entityBehaviour.EntityId;

        private void Awake()
        {
            if (_entityBehaviour == null)
                _entityBehaviour = GetComponent<EntityBehaviour>();
        }
    }
}