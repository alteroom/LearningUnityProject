using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives.Events
{
    public sealed class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 value)
        {
            Debug.Log($"Event {name} with {value} was received!");
            this.OnEvent?.Invoke(value);
        }
        
        [Button]
        public void Forward()
        {
            Call(Vector3.forward);
        }
        [Button]
        public void Back()
        {
            Call(Vector3.back);
        }
        [Button]
        public void Left()
        {
            Call(Vector3.left);
        }
        [Button]
        public void Right()
        {
            Call(Vector3.right);
        }
    }
}