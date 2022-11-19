using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 value)
        {
            Debug.Log($"Event {name} with {value} was received!");
            this.OnEvent?.Invoke(value);
        }
    }
}