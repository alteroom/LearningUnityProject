namespace Modules.UISystem.Base
{
    public interface IWindowFactory<in TKey, out TValue> where TValue : IWindow
    {
        TValue CreateWindow(TKey key);
    }
}