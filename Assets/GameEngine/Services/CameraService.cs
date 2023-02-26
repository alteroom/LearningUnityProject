using UnityEngine;

namespace GameEngine.Services
{
    public class CameraService : MonoBehaviour, ICameraService
    {
        [SerializeField] 
        private Camera m_Camera;
        public Camera Camera => m_Camera;
        public Transform CameraTransform => m_Camera.transform;
    }
}