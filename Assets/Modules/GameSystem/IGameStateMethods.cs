using System;

namespace Modules.GameSystem
{
    public interface IGameStateMethods
    {
        
        void ConstructGame();
        void InitGame();

        void ReadyGame();

        void StartGame();

        void PauseGame();
        
        void ResumeGame();
    
        void FinishGame();
    }
}