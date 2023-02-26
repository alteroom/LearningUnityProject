using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    public sealed class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField]
        private IntEventReceiver m_TakeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            m_TakeDamageReceiver.Call(damage);
        }
    }
}