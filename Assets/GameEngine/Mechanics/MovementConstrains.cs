using System;
using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public class MovementConstrains : MonoBehaviour
    {
        [SerializeField] 
        private RigidbodyBehaviour targetRigidbody;
        
        private Vector3 Velocity => this.targetRigidbody.Value.velocity;
        
        public bool OnTheGround
        {
            get
            {
                return Mathf.Abs(Velocity.y) <= 0.01f;
            }
        }
    }
}