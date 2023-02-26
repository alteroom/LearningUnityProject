using Modules.GameSystem.GameElements;

namespace Modules.GameSystem.Context
{
    public interface IGameElementsContext
    {
        void RegisterElement(IGameElement element);

        void UnregisterElement(IGameElement element);

        IGameElement[] GetAllElements();
    }
}