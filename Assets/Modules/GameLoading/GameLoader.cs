using System.Collections;
using Modules.GameSystem.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.GameLoading
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private bool m_LoadOnStart;
        [SerializeField]
        private MonoGameContext m_GameContext;

        void Start()
        {
            if (m_LoadOnStart)
            {
                LoadGame();
            }
        }
        [Button]
        private void LoadGame()
        {
            AddListeners();
            m_GameContext.ConstructGame();
        
        }

        private void AddListeners()
        {
            m_GameContext.OnGameConstructed += OnGameConstructed;
            m_GameContext.OnGameInitialized += OnGameInitialized;
            m_GameContext.OnGameReady += OnGameReady;
            m_GameContext.OnGameStarted += OnGameStarted;
        }
        private void RemoveListeners()
        {
            m_GameContext.OnGameConstructed -= OnGameConstructed;
            m_GameContext.OnGameInitialized -= OnGameInitialized;
            m_GameContext.OnGameReady -= OnGameReady;
            m_GameContext.OnGameStarted -= OnGameStarted;
        }
        private void OnGameConstructed()
        {
            m_GameContext.InitGame();
        }

        private void OnGameInitialized()
        {
            m_GameContext.ReadyGame();
        }

        private void OnGameReady()
        {
            StartCoroutine(StartGameCountdown());
        }
        private readonly WaitForSeconds m_WaitForOneSecond = new WaitForSeconds(1);
        private IEnumerator StartGameCountdown()
        {
            Debug.Log("3");
            yield return m_WaitForOneSecond;
            Debug.Log("2");
            yield return m_WaitForOneSecond;
            Debug.Log("1");
            yield return m_WaitForOneSecond;
            Debug.Log("START");
            m_GameContext.StartGame();
        }

        private void OnGameStarted()
        {
            RemoveListeners();
        }

    
    }
}
