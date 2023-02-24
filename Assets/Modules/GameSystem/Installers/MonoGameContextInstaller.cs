using System.Collections.Generic;
using Modules.GameSystem.Context;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.GameSystem.Installers
{
    public class MonoGameContextInstaller : MonoBehaviour
    {
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