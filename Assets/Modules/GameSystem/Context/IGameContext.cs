using Modules.GameSystem.GameState;

namespace Modules.GameSystem.Context
{
    public interface IGameContext : IGameElementsContext, IServicesContext, IGameStateMethods, IGameStateEvents
    {
        GameStates State { get; }
    }
}
