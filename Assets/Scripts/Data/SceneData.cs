using Features.Enemy.Services;
using Features.Player.Services;
using UnityEngine;
using Views.Services;

namespace Data
{
    public class SceneData : MonoBehaviour
    {
        public EntityViewFactory EntityViewFactory;
        public PlayerFactory PlayerFactory;
        public EnemyFactory EnemyFactory;
    }
}