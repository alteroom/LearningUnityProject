namespace Modules.GameSystem
{
    public interface IGameElementsContext
    {
        void RegisterElement(IGameElement element);

        void UnregisterElement(IGameElement element);

        IGameElement[] GetAllElements();
    }
}