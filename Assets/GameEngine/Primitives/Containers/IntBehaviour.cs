using System;
using UnityEngine;

namespace GameEngine.Primitives.Containers
{
    public sealed class IntBehaviour : MonoBehaviour
    {
        public event Action<int> OnValueChanged;

        public int Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private int value;
    }
}