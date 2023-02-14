using System;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives.Containers
{
    public sealed class TransformBehaviour : MonoBehaviour
    {
        public event Action<Transform> OnValueChanged;

        public Transform Value
        {
            get { return this.value; }
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