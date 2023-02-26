using System;
using System.Collections.Generic;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameState;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.GameSystem.Installers
{
    public class MonoGameContextInstaller : MonoBehaviour, IGameStateEvents
    {
        public event Action OnGameConstructed
        {
            add => m_GameContext.OnGameConstructed += value;
            remove => m_GameContext.OnGameConstructed -= value;
        }

        public event Action OnGameInitialized
        {
            add => m_GameContext.OnGameInitialized += value;
            remove => m_GameContext.OnGameInitialized -= value;
        }

        public event Action OnGameReady
        {
            add => m_GameContext.OnGameReady += value;
            remove => m_GameContext.OnGameReady -= value;
        }

        public event Action OnGameStarted
        {
            add => m_GameContext.OnGameStarted += value;
            remove => m_GameContext.OnGameStarted -= value;
        }

        public event Action OnGamePaused
        {
            add => m_GameContext.OnGamePaused += value;
            remove => m_GameContext.OnGamePaused -= value;
        }

        public event Action OnGameResumed
        {
            add => m_GameContext.OnGameResumed += value;
            remove => m_GameContext.OnGameResumed -= value;
        }

        public event Action OnGameFinished
        {
            add => m_GameContext.OnGameFinished += value;
            remove => m_GameContext.OnGameFinished -= value;
        }   
        
        private readonly GameContext m_GameContext = new ();
        private readonly GameContextInstaller m_Installer = new ();

        [SerializeField]
        private List<MonoBehaviour> gameServices = new();

        [Space]
        [SerializeField]
        private List<MonoBehaviour> gameElements = new();
        
        [Button]
        public void ConstructGame()
        {
            m_Installer.RegisterServices(gameServices, m_GameContext);
            m_Installer.RegisterElements(gameElements, m_GameContext);
            m_GameContext.ConstructGame();
        }

        [Button]
        public void InitGame()
        {
            m_GameContext.InitGame();
        }
        [Button]
        public void ReadyGame()
        {
            m_GameContext.ReadyGame();
        }
        [Button]
        public void StartGame()
        {
            m_GameContext.StartGame();
        }
        [Button]
        public void PauseGame()
        {
            m_GameContext.PauseGame();
        }
        [Button]
        public void ResumeGame()
        {
            m_GameContext.ResumeGame();
        }
        [Button]
        public void FinishGame()
        {
            m_GameContext.FinishGame();
        }

       
    }
}