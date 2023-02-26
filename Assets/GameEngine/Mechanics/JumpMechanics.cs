using GameEngine.Primitives.Containers;
using GameEngine.Primitives.Events;
using GameEngine.Primitives.Timers;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public sealed class JumpMechanics : MonoBehaviour
    {
        [SerializeField] 
        private FloatBehaviour jumpForce;

        [SerializeField] 
        private EventReceiver jumpEventReceiver;

        [SerializeField] 
        private RigidbodyBehaviour targetRigidbody;

        [SerializeField] 
        private MovementConstrains movementConstrains;
        
        [SerializeField] 
        private TimerBehaviour countdown;
        private void OnEnable()
        {
            this.jumpEventReceiver.OnEvent += OnJump;
        }

        private void OnDisable()
        {
            this.jumpEventReceiver.OnEvent -= OnJump;
        }
        private bool CanJump => movementConstrains.OnTheGround && !countdown.IsPlaying;
        private void OnJump()
        {
            if (CanJump)
            {
                this.targetRigidbody.Value.AddForce(0, jumpForce.Value, 0);
                this.countdown.ResetTime();
                this.countdown.Play();
            }
        }
    }
}