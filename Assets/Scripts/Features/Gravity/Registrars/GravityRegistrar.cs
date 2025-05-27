using Features.Gravity.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Registrars
{
    public class GravityRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float _gravity = 9.81f;

        public override void RegisterComponents()
        {
            AddToPool<GravityComponent>().Value = _gravity;
        }

        public override void UnregisterComponents()
        {
            RemoveFromPool<GravityComponent>();
        }
    }
}