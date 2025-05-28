using Features.Movement.Components;
using Infrastructure.Registrars;
using UnityEngine;

namespace Registrars
{
    public class JumpRegistrar  : EntityComponentRegistrar
    {
        [SerializeField] private float _jumpForce;

        public override void RegisterComponents()
        {
            AddToPool<JumpForceComponent>().Value = _jumpForce;
        }
        public override void UnregisterComponents()
        {
            DeleteFromPool<JumpForceComponent>();
        }
    }
}