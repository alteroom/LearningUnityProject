using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    public sealed class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField]
        private Vector3EventReceiver m_ShootInDirectionReceiver;
        
        public void Shoot(Vector3 direction)
        {
            m_ShootInDirectionReceiver.Call(direction);
        }
    }
}