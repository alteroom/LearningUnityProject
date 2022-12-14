using System;
using Homeworks._1_GameMechanics.Scripts.Primitives;
using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField] 
        private Vector3EventReceiver moveEventReceiver;
        
        [SerializeField]
        private TransformBehaviour targetTransform;
        
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
            Debug.Log($"Move {targetTransform.name} to vector: {direction}");
            this.targetTransform.Value.position += direction;
        }
    }
}