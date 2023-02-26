using GameEngine.Components;
using Homeworks.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Controllers
{
    public sealed class JumpController : MonoBehaviour, 
        IGameConstructElement, 
        IGameStartElement, 
        IGamePauseElement, 
        IGameResumeElement, 
        IGameFinishElement
    {
        [SerializeField] 
        private InputMap m_InputMap;
        
        private IJumpComponent m_JumpComponent;
        
        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            if (Input.GetKey(m_InputMap.JumpKeyCode))
            {
                m_JumpComponent.Jump();
            }
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            var entity = context.GetService<HeroService>().GetCharacter();
            m_JumpComponent = entity.Get<IJumpComponent>();
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