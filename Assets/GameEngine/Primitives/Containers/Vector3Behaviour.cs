using System;
using UnityEngine;

namespace GameEngine.Primitives.Containers
{
    public sealed class Vector3Behaviour : MonoBehaviour
    {
        public event Action<Vector3> OnValueChanged;

        public Vector3 Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private Vector3 value;
    }
}