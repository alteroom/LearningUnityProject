using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
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