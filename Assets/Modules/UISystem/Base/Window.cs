using UnityEngine;
using UnityEngine.Events;

namespace Modules.UISystem.Base
{
    public class Window : MonoBehaviour, IWindow
    {
        [SerializeField] 
        private UnityEvent<object> m_OnShow;
        
        [SerializeField] 
        private UnityEvent m_OnHide;

        private IWindowCallback m_Callback;
        
        public void Show(object args = null, IWindowCallback callback = null)
        {
            m_Callback = callback;
            OnShow();
            m_OnShow?.Invoke(args);
        }

        public void Hide()
        {
            OnHide();
            m_OnHide?.Invoke();
        }

        public void Close()
        {
            if (m_Callback != null)
            {
                m_Callback.OnClose(this);
            }
        }

        protected virtual void OnShow(object args = null)
        {
            
        }

        protected virtual void OnHide()
        {
            
        }
    }
}