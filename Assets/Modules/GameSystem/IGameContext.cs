
using System;

namespace Modules.GameSystem
{
    public interface IGameContext 
    {
        event Action OnGameInitialized;

        event Action OnGameReady;
        
        event Action OnGameStarted;
        
        event Action OnGamePaused;

        event Action OnGameResumed;

        event Action OnGameFinished;

        GameState State { get; }

        void InitGame();

        void ReadyGame();

        void StartGame();

        void PauseGame();
        
        void ResumeGame();
    
        void FinishGame();

        /// Elements:
        void RegisterElement(IGameElement element);

        void UnregisterElement(IGameElement element);

        object[] GetAllElements();
    }
}
