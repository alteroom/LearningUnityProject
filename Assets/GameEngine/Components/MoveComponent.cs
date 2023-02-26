using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    public sealed class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] 
        private Vector3EventReceiver m_MoveEventReceiver;
        
        public void Move(Vector3 direction)
        {
            m_MoveEventReceiver.Call(direction);
        }
    }
}