using Modules.GameSystem.GameState;

namespace Modules.GameSystem.Context
{
    public interface IGameContext : IGameElementsContext, IServicesContext, IGameStateMethods
    {
        GameStates State { get; }
    }
}
