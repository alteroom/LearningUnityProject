namespace Modules.UISystem.Base
{
    public interface IWindowSupplier<in TKey, TValue> where TValue : IWindow
    {
        TValue LoadWindow(TKey key);
        
        void UnloadWindow(TValue window);
    }
}