using System;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives.Containers
{
    public sealed class FloatBehaviour : MonoBehaviour
    {
        public event Action<float> OnValueChanged;

        public float Value
        {
            get { return this.value; }
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