using Modules.GameSystem.GameState;

namespace Modules.GameSystem.Context
{
    public interface IGameContext : IGameElementsContext, IServicesContext, IGameStateObserver, IGameStateObservable
    {
        GameStates State { get; }
    }
}
