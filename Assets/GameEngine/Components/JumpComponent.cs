using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    public sealed class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField] 
        private EventReceiver m_JumpEventReceiver;
        
        public void Jump()
        {
            m_JumpEventReceiver.Call();
        }
    }
}