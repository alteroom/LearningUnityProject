namespace Modules.UISystem.Base
{
    public interface IWindow
    {
        void Show(object args = null, IWindowCallback callback = null);
        void Hide();
    }
}