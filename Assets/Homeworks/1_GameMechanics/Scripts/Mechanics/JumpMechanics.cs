using System;
using Homeworks._1_GameMechanics.Scripts.Primitives;
using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using Unity.Collections;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public sealed class JumpMechanics : MonoBehaviour
    {
        [SerializeField] 
        private FloatBehaviour jumpForce;

        [SerializeField] 
        private EventReceiver jumpEventReceiver;

        [SerializeField] 
        private RigidbodyBehaviour targetRigidbody;
        
        private void OnEnable()
        {
            this.jumpEventReceiver.OnEvent += OnJump;
        }

        private void OnDisable()
        {
            this.jumpEventReceiver.OnEvent -= OnJump;
        }

        private Vector3 Velocity => this.targetRigidbody.Value.velocity;
        private bool CanJump => Mathf.Abs(Velocity.y) <= Single.Epsilon;
        private void OnJump()
        {
            if (CanJump)
            {
                Debug.Log("Jump");
                this.targetRigidbody.Value.AddForce(0, jumpForce.Value, 0);
            }
            else
            {
                Debug.Log("Can't jump on the fly");
            }
            
        }
    }
}