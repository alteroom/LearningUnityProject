using System;
using UnityEngine;

namespace GameEngine.Primitives.Containers
{
    public sealed class RigidbodyBehaviour : MonoBehaviour
    {
        public event Action<Rigidbody> OnValueChanged;

        public Rigidbody Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private Rigidbody value;
    }
}