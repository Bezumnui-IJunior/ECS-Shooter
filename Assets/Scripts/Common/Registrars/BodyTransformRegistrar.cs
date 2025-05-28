using Common.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Common.Registrars
{
    public class BodyTransformRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Transform _bodyTransform;

        public override void RegisterComponents()
        {
            AddToPool<BodyTransformComponent>().Value = _bodyTransform;
        }

        public override void UnregisterComponents()
        {
            DeleteFromPool<BodyTransformComponent>();
        }
    }
}