using GameEngine.Components;
using GameEngine.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;

namespace GameEngine.CameraFollow
{
    public class CameraFollower : MonoBehaviour, IGameConstructElement, IGameStartElement, IGameFinishElement
    {
        private Transform m_TargetTransform;
        private Transform m_FollowTransform;
        private Camera m_Camera;
        [SerializeField]
        private Vector3 m_FollowOffset;

        private void Awake()
        {
            enabled = false;
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            var entity = context.GetService<HeroService>().GetCharacter();
            m_FollowTransform = entity.Get<ITransformComponent>().Transform;

            var cameraService = context.GetService<ICameraService>();
            m_TargetTransform = cameraService.CameraTransform;
            m_Camera = cameraService.Camera;
            //var offset = m_TargetTransform.position - m_FollowTransform.position;
            //Debug.Log(offset);
            //m_FollowOffset = offset;
        }

        private void LateUpdate()
        {
            m_TargetTransform.position = m_FollowTransform.position + m_FollowOffset;
            m_TargetTransform.LookAt(m_FollowTransform);
        }

        void IGameStartElement.StartGame()
        {
            enabled = true;
        }

        void IGameFinishElement.FinishGame()
        {
            enabled = false;
        }
    }
}