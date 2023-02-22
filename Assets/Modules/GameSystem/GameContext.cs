using System;
using UnityEngine;

namespace Modules.GameSystem
{
    public class GameContext : IGameContext
    {
        public event Action OnGameInitialized;
        public event Action OnGameReady;
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;
        public GameState State { get; private set; }

        public GameContext()
        {
            this.State = GameState.None;
            
        }
        
        public void InitGame()
        {
            if (this.State == GameState.None)
            {
                this.State = GameState.Init;
                Debug.Log("InitGame");
                OnGameInitialized?.Invoke();
            }
        }

        public void ReadyGame()
        {
            if (this.State == GameState.Init)
            {
                this.State = GameState.Ready;
                Debug.Log("Ready");
                OnGameReady?.Invoke();
            }
        }

        public void StartGame()
        {
            if (this.State == GameState.Ready)
            {
                this.State = GameState.Play;
                Debug.Log("Play");
                OnGameStarted?.Invoke();
            }
        }

        public void PauseGame()
        {
            if (this.State == GameState.Play)
            {
                this.State = GameState.Pause;
                Debug.Log("Pause");
                OnGamePaused?.Invoke();
            }
        }

        public void ResumeGame()
        {
            if (this.State == GameState.Pause)
            {
                this.State = GameState.Play;
                Debug.Log("Play");
                OnGameResumed?.Invoke();
            }
        }

        public void FinishGame()
        {
            if (this.State == GameState.Play || this.State == GameState.Pause)
            {
                this.State = GameState.Finish;
                Debug.Log("Finish");
                OnGameFinished?.Invoke();
            }
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