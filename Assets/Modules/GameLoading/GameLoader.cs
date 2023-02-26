using System.Collections;
using Modules.GameSystem.Installers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.GameLoading
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private bool m_LoadOnStart;

        [SerializeField]
        private MonoGameContextInstaller m_GameInstaller;

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
            m_GameInstaller.ConstructGame();
        
        }

        private void AddListeners()
        {
            m_GameInstaller.OnGameConstructed += OnGameConstructed;
            m_GameInstaller.OnGameInitialized += OnGameInitialized;
            m_GameInstaller.OnGameReady += OnGameReady;
            m_GameInstaller.OnGameStarted += OnGameStarted;
        }
        private void RemoveListeners()
        {
            m_GameInstaller.OnGameConstructed -= OnGameConstructed;
            m_GameInstaller.OnGameInitialized -= OnGameInitialized;
            m_GameInstaller.OnGameReady -= OnGameReady;
            m_GameInstaller.OnGameStarted -= OnGameStarted;
        }
        private void OnGameConstructed()
        {
            m_GameInstaller.InitGame();
        }

        private void OnGameInitialized()
        {
            m_GameInstaller.ReadyGame();
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
            m_GameInstaller.StartGame();
        }

        private void OnGameStarted()
        {
            RemoveListeners();
        }

    
    }
}
