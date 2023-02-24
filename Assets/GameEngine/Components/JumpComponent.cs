using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Components
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