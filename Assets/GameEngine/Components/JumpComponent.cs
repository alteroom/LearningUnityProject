using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
{
    public sealed class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField] 
        private EventReceiver jumpEventReceiver;
        
        public void Jump()
        {
            jumpEventReceiver.Call();
        }
    }
}