using GameEngine.Components;
using GameEngine.Entities;
using GameEngine.Primitives.Collision;
using GameEngine.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;


namespace GameEngine.Controllers
{
    public class DeathController : MonoBehaviour, 
        IGameConstructElement, 
        IGameStartElement, 
        IGamePauseElement, 
        IGameResumeElement, 
        IGameFinishElement
    {
        private IGameContext m_Context;
        private TriggerEnterBehaviour m_AbyssTrigger;

        private void Awake()
        {
            enabled = false;
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            m_Context = context;
            m_AbyssTrigger = context.GetService<AbyssService>().GetTrigger();
            
        }

        private void OnAbyssTrigger(Collider other, object reason)
        {
            Debug.Log("OnAbyssTrigger");
            if (!other.TryGetComponent(out IEntity entity))
            {
                Debug.LogError("No Entity Component");
                return;
            }

            if (!entity.TryGet(out IDeathComponent deathComponent))
            {
                Debug.LogError("No Death Component");
                return;
            }
            Debug.Log($"Death {reason}");
            deathComponent.Death(reason);
        }

        
        void IGameStartElement.StartGame()
        {
            m_AbyssTrigger.OnEvent += OnAbyssTrigger;
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
            m_AbyssTrigger.OnEvent -= OnAbyssTrigger;
            enabled = false;
        }
    }
}