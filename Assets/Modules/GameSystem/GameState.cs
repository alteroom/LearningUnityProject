using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameSystem
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

        private readonly Dictionary<GameElements, Predicate<GameStates>> m_TransitPredicates;
        public GameStates State { get; private set; }

        public GameState()
        {
            State = GameStates.None;
            m_TransitPredicates = new Dictionary<GameElements,  Predicate<GameStates>>
            {
                {GameElements.Construct, state => state == GameStates.None},
                {GameElements.Init, state => state == GameStates.Construct},
                {GameElements.Ready, state => state == GameStates.Init},
                {GameElements.Start, state => state == GameStates.Ready},
                {GameElements.Pause, state => state == GameStates.Play},
                {GameElements.Resume, state => state == GameStates.Pause},
                {GameElements.Finish, state => state == GameStates.Play || state == GameStates.Pause},
            };
        }

        public bool CanTransit(GameElements element)
        {
            var condition = m_TransitPredicates[element];
            return condition(State);
        }
        public void ConstructGame()
        {
            if (CanTransit(GameElements.Construct))
            {
                this.State = GameStates.Construct;
                Debug.Log("ConstructGame");
                OnGameConstructed?.Invoke();
            }
        }

        public void InitGame()
        {
            if (CanTransit(GameElements.Init))
            {
                this.State = GameStates.Init;
                Debug.Log("InitGame");
                OnGameInitialized?.Invoke();
            }
        }

        public void ReadyGame()
        {
            if (CanTransit(GameElements.Ready))
            {
                this.State = GameStates.Ready;
                Debug.Log("Ready");
                OnGameReady?.Invoke();
            }
        }

        public void StartGame()
        {
            if (CanTransit(GameElements.Start))
            {
                this.State = GameStates.Play;
                Debug.Log("Play");
                OnGameStarted?.Invoke();
            }
        }

        public void PauseGame()
        {
            if (CanTransit(GameElements.Pause))
            {
                this.State = GameStates.Pause;
                Debug.Log("Pause");
                OnGamePaused?.Invoke();
            }
        }

        public void ResumeGame()
        {
            if (CanTransit(GameElements.Resume))
            {
                this.State = GameStates.Play;
                Debug.Log("Play");
                OnGameResumed?.Invoke();
            }
        }

        public void FinishGame()
        {
            if (CanTransit(GameElements.Finish))
            {
                this.State = GameStates.Finish;
                Debug.Log("Finish");
                OnGameFinished?.Invoke();
            }
        }
    }
}