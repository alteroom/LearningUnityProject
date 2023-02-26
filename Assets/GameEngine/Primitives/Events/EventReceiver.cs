using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Primitives.Events
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [Button]
        public void Call()
        {
            OnEvent?.Invoke();
        }
    }
}