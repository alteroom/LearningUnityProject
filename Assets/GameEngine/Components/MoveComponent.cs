using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
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