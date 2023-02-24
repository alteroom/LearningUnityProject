using GameEngine.Primitives.Containers;
using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField] 
        private Vector3EventReceiver moveEventReceiver;
        
        [SerializeField]
        private TransformBehaviour targetTransform;
        
        [SerializeField] 
        private MovementConstrains constrains;

        [SerializeField] 
        private FloatBehaviour moveSpeed;

        private bool CanMove => constrains.OnTheGround;
        private void OnEnable()
        {
            this.moveEventReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            this.moveEventReceiver.OnEvent -= OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            if (CanMove)
            {
                this.targetTransform.Value.position += direction * this.moveSpeed.Value;
            }
        }
    }
}