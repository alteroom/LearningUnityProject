using System;
using Homeworks._1_GameMechanics.Scripts.Primitives;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public class MoveMechanics : MonoBehaviour
    {
        [SerializeField] 
        private Vector3EventReceiver moveEventReceiver;
        
        [SerializeField]
        private TransformBehaviour targetTransform;

        [SerializeField] 
        private FloatBehaviour movementSpeed;
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
            var offset = direction.normalized * movementSpeed.Value * Time.deltaTime;
            Debug.Log($"Move {targetTransform.name} to vector: {offset}");
            this.targetTransform.Value.position += offset;
        }
    }
}