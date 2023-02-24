
using System;

namespace Modules.GameSystem
{
    public interface IGameContext : IGameElementsContext, IServicesContext, IGameStateMethods
    {
        GameStates State { get; }
    }
}
