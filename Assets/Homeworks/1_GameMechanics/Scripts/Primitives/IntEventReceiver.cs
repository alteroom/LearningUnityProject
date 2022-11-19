using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives
{
    public sealed class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> OnEvent;

        [Button]
        public void Call(int value)
        {
            Debug.Log($"Event {name} with {value} was received!");
            this.OnEvent?.Invoke(value);
        }
    }
}