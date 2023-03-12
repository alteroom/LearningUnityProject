using System;
using Modules.GameSystem.GameElements;
using Modules.GameSystem.GameState;
using UnityEngine;

namespace Modules.GameSystem.Context
{
    public class GameContext : IGameContext
    {
        public event Action OnGameConstructed;
        public event Action OnGameInitialized;
        public event Action OnGameReady;
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;

        public GameStates State { get; private set; }
        
        private readonly ElementsContext m_ElementsContext;
        private readonly ServicesContext m_ServicesContext = new ();
        
        public GameContext()
        {
            State = GameStates.None;
            m_ElementsContext = new (this);
        }

        public void ConstructGame()
        {
            if (State != GameStates.None)
            {
                return;
            }
            Debug.Log("ConstructGame");
            m_ElementsContext.ConstructGame();
            State = GameStates.Construct;
            OnGameConstructed?.Invoke();
            
        }

        public void InitGame()
        {
            if (State != GameStates.Construct)
            {
                return;
            }
            Debug.Log("InitGame");
            m_ElementsContext.InitGame();
            State = GameStates.Init;
            OnGameInitialized?.Invoke();
            
        }

        public void ReadyGame()
        {
            if (State != GameStates.Init)
            {
                return;
            }
            Debug.Log("ReadyGame");
            m_ElementsContext.ReadyGame();
            State = GameStates.Ready;
            OnGameReady?.Invoke();
            
        }

        public void StartGame()
        {
            if (State != GameStates.Ready)
            {
                return;
            }
            Debug.Log("StartGame");
            m_ElementsContext.StartGame();
            State = GameStates.Play;
            OnGameStarted?.Invoke();
        }

        public void PauseGame()
        {
            if (State != GameStates.Play)
            {
                return;
            }
            Debug.Log("PauseGame");
            m_ElementsContext.PauseGame();
            State = GameStates.Pause;
            OnGamePaused?.Invoke();
            
        }

        public void ResumeGame()
        {
            if (State != GameStates.Pause)
            {
                return;
            }
            Debug.Log("ResumeGame");
            m_ElementsContext.ResumeGame();
            State = GameStates.Play;
            OnGameResumed?.Invoke();
           
        }

        public void FinishGame()
        {
            if (State != GameStates.Play && State != GameStates.Pause)
            {
                return;
            }
            Debug.Log("FinishGame");
            m_ElementsContext.FinishGame();
            State = GameStates.Finish;
            OnGameFinished?.Invoke();
        }

        public void RegisterElement(IGameElement element)
        {
            m_ElementsContext.RegisterElement(element);
        }

        public void UnregisterElement(IGameElement element)
        {
            m_ElementsContext.UnregisterElement(element);
        }

        public IGameElement[] GetAllElements()
        {
            return m_ElementsContext.GetAllElements();
        }

        public void RegisterService(object service)
        {
            m_ServicesContext.RegisterService(service);
        }

        public void UnregisterService(object service)
        {
            m_ServicesContext.UnregisterService(service);
        }

        public T GetService<T>()
        {
            return m_ServicesContext.GetService<T>();
        }

        public bool TryGetService<T>(out T service)
        {
            return m_ServicesContext.TryGetService(out service);
        }

        public T[] GetServices<T>()
        {
            return m_ServicesContext.GetServices<T>();
        }
    }
}