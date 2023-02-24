using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Components
{
    public sealed class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField]
        private IntEventReceiver takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            takeDamageReceiver.Call(damage);
        }
    }
}