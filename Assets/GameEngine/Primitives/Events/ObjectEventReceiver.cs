using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Primitives.Events
{
    public class ObjectEventReceiver : MonoBehaviour
    {
        public event Action<object> OnEvent;

        [Button]
        public void Call(object value)
        {
            OnEvent?.Invoke(value);
        }
    }
}