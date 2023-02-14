using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives.Events
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [Button]
        public void Call()
        {
            this.OnEvent?.Invoke();
        }
    }
}