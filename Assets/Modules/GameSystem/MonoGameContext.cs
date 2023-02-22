using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.GameSystem
{
    public class MonoGameContext : MonoBehaviour, IGameContext
    {
        public event Action OnGameInitialized
        {
            add { _gameContext.OnGameInitialized += value; }
            remove { _gameContext.OnGameInitialized -= value; }
        }

        public event Action OnGameReady {
            add { _gameContext.OnGameReady += value; }
            remove { _gameContext.OnGameReady -= value; }
        }
        public event Action OnGameStarted {
            add { _gameContext.OnGameStarted += value; }
            remove { _gameContext.OnGameStarted -= value; }
        }
        public event Action OnGamePaused {
            add { _gameContext.OnGamePaused += value; }
            remove { _gameContext.OnGamePaused -= value; }
        }
        public event Action OnGameResumed {
            add { _gameContext.OnGameResumed += value; }
            remove { _gameContext.OnGameResumed -= value; }
        }
        public event Action OnGameFinished {
            add { _gameContext.OnGameFinished += value; }
            remove { _gameContext.OnGameFinished -= value; }
        }
        public GameState State => _gameContext.State;

        private readonly GameContext _gameContext = new ();
        
        [Button]
        public void InitGame()
        {
            _gameContext.InitGame();
        }
        [Button]
        public void ReadyGame()
        {
            _gameContext.ReadyGame();
        }
        [Button]
        public void StartGame()
        {
            _gameContext.StartGame();
        }
        [Button]
        public void PauseGame()
        {
            _gameContext.PauseGame();
        }
        [Button]
        public void ResumeGame()
        {
            _gameContext.ResumeGame();
        }
        [Button]
        public void FinishGame()
        {
            _gameContext.FinishGame();
        }

        public void RegisterElement(IGameElement element)
        {
            throw new NotImplementedException();
        }

        public void UnregisterElement(IGameElement element)
        {
            throw new NotImplementedException();
        }

        public object[] GetAllElements()
        {
            throw new NotImplementedException();
        }
    }
}