using GameEngine.Primitives.Containers;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class MovementConstrains : MonoBehaviour
    {
        [SerializeField] 
        private RigidbodyBehaviour targetRigidbody;
        
        private Vector3 Velocity => this.targetRigidbody.Value.velocity;
        
        public bool OnTheGround => Mathf.Abs(Velocity.y) <= 0.01f;
    }
}