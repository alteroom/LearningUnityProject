using System;

namespace Modules.UISystem.Base
{
    public interface IPopupManager<TKey>
    {
        event Action<TKey> OnPopupShown;
        
        event Action<TKey> OnPopupHidden;

        void ShowPopup(TKey key, object args = null);

        void HidePopup(TKey key);

        bool IsPopupInStack(TKey key);
        
        bool IsPopupOnTop(TKey key);

        void HideAllPopups();

    }
}