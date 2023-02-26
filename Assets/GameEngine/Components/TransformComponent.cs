using UnityEngine;

namespace GameEngine.Components
{
    public class TransformComponent: MonoBehaviour, ITransformComponent
    {
        [SerializeField] 
        private Transform m_Transform;

        public Transform Transform => m_Transform;
    }
}