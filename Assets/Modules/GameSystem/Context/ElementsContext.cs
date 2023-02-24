using System.Collections.Generic;
using Modules.GameSystem.GameElements;
using Modules.GameSystem.GameState;

namespace Modules.GameSystem.Context
{
    internal class ElementsContext : IGameElementsContext, IGameStateMethods
    {
        private readonly IGameContext m_GameContext;

        private List<IGameElement> m_Elements = new();
        internal ElementsContext(IGameContext context)
        {
            m_GameContext = context;
        }
        public void RegisterElement(IGameElement element)
        {
            if (m_Elements.Contains(element))
            {
                return;
            }
            m_Elements.Add(element);
        }

        public void UnregisterElement(IGameElement element)
        {
            if (m_Elements.Contains(element))
            {
                m_Elements.Remove(element);
            }
        }

        public IGameElement[] GetAllElements()
        {
            return m_Elements.ToArray();
        }

        public void ConstructGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameConstructElement constructElement)
                {
                    constructElement.ConstructGame(m_GameContext);
                }
            }
        }

        public void InitGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameInitElement initElement)
                {
                    initElement.InitGame();
                }
            }
        }

        public void ReadyGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameReadyElement readyElement)
                {
                    readyElement.ReadyGame();
                }
            }
        }

        public void StartGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameStartElement startElement)
                {
                    startElement.StartGame();
                }
            }
        }

        public void PauseGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGamePauseElement pauseElement)
                {
                    pauseElement.PauseGame();
                }
            }
        }

        public void ResumeGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameResumeElement resumeElement)
                {
                    resumeElement.ResumeGame();
                }
            }
        }

        public void FinishGame()
        {
            foreach (var element in m_Elements)
            {
                if (element is IGameFinishElement finishElement)
                {
                    finishElement.FinishGame();
                }
            }
        }
    }
}