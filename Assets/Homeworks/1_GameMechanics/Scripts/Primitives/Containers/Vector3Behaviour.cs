using System;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Primitives.Containers
{
    public sealed class Vector3Behaviour : MonoBehaviour
    {
        public event Action<Vector3> OnValueChanged;

        public Vector3 Value
        {
            get { return this.value; }
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