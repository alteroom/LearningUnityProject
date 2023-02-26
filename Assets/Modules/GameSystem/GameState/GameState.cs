using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameSystem.GameState
{
    public class GameState
    {
        public event Action OnGameConstructed;
        public event Action OnGameInitialized;
        public event Action OnGameReady;
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;

        private readonly Dictionary<GameElements.GameElements, Predicate<GameStates>> m_TransitPredicates;
        public GameStates State { get; private set; }

        public GameState()
        {
            State = GameStates.None;
            m_TransitPredicates = new Dictionary<GameElements.GameElements,  Predicate<GameStates>>
            {
                {GameElements.GameElements.Construct, state => state == GameStates.None},
                {GameElements.GameElements.Init, state => state == GameStates.Construct},
                {GameElements.GameElements.Ready, state => state == GameStates.Init},
                {GameElements.GameElements.Start, state => state == GameStates.Ready},
                {GameElements.GameElements.Pause, state => state == GameStates.Play},
                {GameElements.GameElements.Resume, state => state == GameStates.Pause},
                {GameElements.GameElements.Finish, state => state == GameStates.Play || state == GameStates.Pause},
            };
        }

        public bool CanTransit(GameElements.GameElements element)
        {
            var condition = m_TransitPredicates[element];
            return condition(State);
        }
        public void ConstructGame()
        {
            if (CanTransit(GameElements.GameElements.Construct))
            {
                this.State = GameStates.Construct;
                Debug.Log("ConstructGame");
                OnGameConstructed?.Invoke();
            }
        }

        public void InitGame()
        {
            if (CanTransit(GameElements.GameElements.Init))
            {
                this.State = GameStates.Init;
                Debug.Log("InitGame");
                OnGameInitialized?.Invoke();
            }
        }

        public void ReadyGame()
        {
            if (CanTransit(GameElements.GameElements.Ready))
            {
                this.State = GameStates.Ready;
                Debug.Log("ReadyGame");
                OnGameReady?.Invoke();
            }
        }

        public void StartGame()
        {
            if (CanTransit(GameElements.GameElements.Start))
            {
                this.State = GameStates.Play;
                Debug.Log("StartGame");
                OnGameStarted?.Invoke();
            }
        }

        public void PauseGame()
        {
            if (CanTransit(GameElements.GameElements.Pause))
            {
                this.State = GameStates.Pause;
                Debug.Log("Pause");
                OnGamePaused?.Invoke();
            }
        }

        public void ResumeGame()
        {
            if (CanTransit(GameElements.GameElements.Resume))
            {
                this.State = GameStates.Play;
                Debug.Log("ResumeGame");
                OnGameResumed?.Invoke();
            }
        }

        public void FinishGame()
        {
            if (CanTransit(GameElements.GameElements.Finish))
            {
                this.State = GameStates.Finish;
                Debug.Log("FinishGame");
                OnGameFinished?.Invoke();
            }
        }
    }
}