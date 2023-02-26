using GameEngine.Components;
using GameEngine.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class FinishGameController : MonoBehaviour, 
        IGameConstructElement, 
        IGameStartElement, 
        IGamePauseElement, 
        IGameResumeElement, 
        IGameFinishElement
    {
        private IDeathComponent m_DeathComponent;
        private IGameContext m_Context;
        private void Awake()
        {
            enabled = false;
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            m_Context = context;
            var entity = context.GetService<HeroService>().GetCharacter();
            m_DeathComponent = entity.Get<IDeathComponent>();
        }

        private void OnDeath(object reason)
        {
            m_Context.FinishGame();
        }

        void IGameStartElement.StartGame()
        {
            m_DeathComponent.OnDeath += OnDeath;
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
            m_DeathComponent.OnDeath -= OnDeath;
            enabled = false;
        }
    }
}