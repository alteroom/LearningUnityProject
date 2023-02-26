using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules.UISystem.Base
{
    public class PopupManager<TKey, TValue> : IPopupManager<TKey>, IWindowCallback where TValue : IWindow
    {
        public event Action<TKey> OnPopupShown;
        public event Action<TKey> OnPopupHidden;

        private readonly Dictionary<TKey, TValue> m_ActivePopups;
        private IWindowSupplier<TKey,TValue> m_Supplier;

        public PopupManager(IWindowSupplier<TKey, TValue> supplier = null)
        {
            m_Supplier = supplier;
            m_ActivePopups = new Dictionary<TKey, TValue>();
        }

        public void Construct(IWindowSupplier<TKey, TValue> supplier)
        {
            m_Supplier = supplier;
        }

        public void ShowPopup(TKey key, object args = null)
        {
            if (!m_ActivePopups.ContainsKey(key))
            {
                Show(key, args);
            }
        }

        public void HidePopup(TKey key)
        {
            if (m_ActivePopups.ContainsKey(key))
            {
                Hide(key);
            }
        }

        public bool IsPopupActive(TKey key)
        {
            return m_ActivePopups.ContainsKey(key);
        }
        
        public void HideAllPopups()
        {
            var keys = m_ActivePopups.Keys.ToArray();
            foreach (var key in keys)
            {
                Hide(key);
            }
        }

        public void OnClose(IWindow window)
        {
            var popup = (TValue) window;
            if (TryFindPopupKey(popup, out var key))
            {
                Hide(key);
            }
        }

        private bool TryFindPopupKey(TValue window, out TKey resultKey)
        {
            foreach (var (key, value) in m_ActivePopups)
            {
                if (ReferenceEquals(value, window))
                {
                    resultKey = key;
                    return true;
                }
            }
            resultKey = default;
            return false;
        }

        private void Show(TKey key, object args = null)
        {
            var popup = m_Supplier.LoadWindow(key);
            popup.Show(args);
            m_ActivePopups.Add(key, popup);
            OnPopupShown?.Invoke(key);
        }
        private void Hide(TKey key)
        {
            var popup = m_ActivePopups[key];
            popup.Hide();
            m_ActivePopups.Remove(key);
            m_Supplier.UnloadWindow(popup);
            OnPopupHidden?.Invoke(key);
        }
    }
}