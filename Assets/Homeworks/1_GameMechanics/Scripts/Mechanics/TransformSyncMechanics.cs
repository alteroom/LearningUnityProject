using System;
using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public class TransformSyncMechanics : MonoBehaviour
    {
        [SerializeField] 
        private Transform sourceTransform;

        [SerializeField] 
        private Transform[] movingTransform;
         
        private Vector3 _oldPosition;
        private void Update()
        {
            if (_oldPosition == sourceTransform.position)
            {
                return;
            }
            foreach (var follower in movingTransform)
            {
                follower.position = sourceTransform.position;
            }
            _oldPosition = sourceTransform.position;
        }
    }
}