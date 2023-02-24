using Modules.GameSystem.GameElements;
using Modules.GameSystem.GameState;

namespace Modules.GameSystem.Context
{
    public class GameContext : IGameContext
    {
        
        public GameStates State => m_GameState.State;

        private readonly GameState.GameState m_GameState = new ();
        private readonly ElementsContext m_ElementsContext;
        private readonly ServicesContext m_ServicesContext = new ();
        public GameContext()
        {
            m_ElementsContext = new (this);
        }

        public void ConstructGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Construct))
            {
                return;
            }
            m_ElementsContext.ConstructGame();
            m_GameState.ConstructGame();
            
        }

        public void InitGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Init))
            {
                return;
            }
            m_ElementsContext.InitGame();
            m_GameState.InitGame();
        }

        public void ReadyGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Ready))
            {
                return;
            }
            m_ElementsContext.ReadyGame();
            m_GameState.ReadyGame();
        }

        public void StartGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Start))
            {
                return;
            }
            m_ElementsContext.StartGame();
            m_GameState.StartGame();
        }

        public void PauseGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Pause))
            {
                return;
            }
            m_ElementsContext.PauseGame();
            m_GameState.PauseGame();
        }

        public void ResumeGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Resume))
            {
                return;
            }
            m_ElementsContext.ResumeGame();
            m_GameState.ResumeGame();
        }

        public void FinishGame()
        {
            if (!m_GameState.CanTransit(GameElements.GameElements.Finish))
            {
                return;
            }
            m_ElementsContext.FinishGame();
            m_GameState.FinishGame();
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