using System;
using UnityEngine;

namespace GameEngine.Primitives.Containers
{
    public sealed class FloatBehaviour : MonoBehaviour
    {
        public event Action<float> OnValueChanged;

        public float Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private float value;
    }
}