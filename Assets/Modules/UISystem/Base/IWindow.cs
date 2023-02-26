namespace Modules.UISystem.Base
{
    public interface IWindow
    {
        bool IsSingleInstance { get; }
        void Show(object args = null, IWindowCallback callback = null);
        void Hide();
    }
}