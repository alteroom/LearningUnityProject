using GameEngine.Components;
using Homeworks.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Controllers
{
    public sealed class MoveController : MonoBehaviour,
        IGameConstructElement, 
        IGameStartElement, 
        IGamePauseElement, 
        IGameResumeElement, 
        IGameFinishElement
    {
        private IMoveComponent m_MoveComponent;
        
        [SerializeField] 
        private InputMap m_InputMap;
        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            if (HasMoveInput(out var direction))
            {
                direction = direction.normalized * Time.deltaTime;
                m_MoveComponent.Move(direction);
            }
            
        }

        private bool HasMoveInput(out Vector3 direction)
        {
            if (Input.GetKey(m_InputMap.LeftKeyCode))
            {
                direction = Vector3.left;
                return true;
            }
            if (Input.GetKey(m_InputMap.RightKeyCode))
            {
                direction = Vector3.right;
                return true;
            }
            if (Input.GetKey(m_InputMap.ForwardKeyCode))
            {
                direction = Vector3.forward;
                return true;
            }
            if (Input.GetKey(m_InputMap.BackKeyCode))
            {
                direction = Vector3.back;
                return true;
            }
            direction = Vector3.zero;
            return false;
        }


        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            var entity = context.GetService<HeroService>().GetCharacter();
            m_MoveComponent = entity.Get<IMoveComponent>();
        }

        void IGameStartElement.StartGame()
        {
            enabled = true;
        }

        void IGamePauseElement.PauseGame()
        {
            enabled = false;
        }

        void IGameResumeElement.ResumeGame()
        {
            enabled = true;
        }

        void IGameFinishElement.FinishGame()
        {
            enabled = false;
        }
    }
}