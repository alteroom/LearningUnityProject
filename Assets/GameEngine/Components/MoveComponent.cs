using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Components
{
    public sealed class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] 
        private Vector3EventReceiver moveEventReceiver;
        
        public void Move(Vector3 direction)
        {
            moveEventReceiver.Call(direction);
        }
    }
}