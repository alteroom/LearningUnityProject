using System;
using UnityEngine;

namespace GameEngine.Primitives.Containers
{
    public sealed class TransformBehaviour : MonoBehaviour
    {
        public event Action<Transform> OnValueChanged;

        public Transform Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private Transform value;
    }
}