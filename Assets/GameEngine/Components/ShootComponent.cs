using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Components
{
    public sealed class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField]
        private Vector3EventReceiver shootInDirectionReceiver;
        
        public void Shoot(Vector3 direction)
        {
            shootInDirectionReceiver.Call(direction);
        }
    }
}