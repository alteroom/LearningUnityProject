using System;

namespace Modules.GameSystem.GameState
{
    public interface IGameStateEvents
    {
        event Action OnGameConstructed;
        event Action OnGameInitialized;
        event Action OnGameReady;
        event Action OnGameStarted;
        event Action OnGamePaused;
        event Action OnGameResumed;
        event Action OnGameFinished;
    }
}