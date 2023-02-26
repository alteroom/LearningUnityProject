using System;
using UnityEngine;

namespace GameEngine.Primitives.Collision
{
    public class TriggerEnterBehaviour : MonoBehaviour
    {
        public event Action<Collider, object> OnEvent;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{this.name} OnTriggerEnter {other.name}");
            OnEvent?.Invoke(other, this);
        }
    }
}