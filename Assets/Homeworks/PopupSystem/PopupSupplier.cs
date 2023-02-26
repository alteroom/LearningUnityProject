using System.Collections.Generic;
using System.Reflection.Emit;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using Modules.UISystem.Base;

namespace Homeworks.PopupSystem
{
    public class PopupSupplier : IWindowSupplier<PopupKey, Window>
    {
        private PopupFactory m_Factory;

        private IGameContext m_Context;

        private readonly Dictionary<PopupKey, Window> m_CachedPopups = new();

        public void Construct(IGameContext context, PopupFactory factory)
        {
            m_Context = context;
            m_Factory = factory;
        }
        public Window LoadWindow(PopupKey key)
        {
            if (m_CachedPopups.TryGetValue(key, out var popup))
            {
                popup.gameObject.SetActive(true);
            }
            else
            {
                popup = m_Factory.CreateWindow(key);
                m_CachedPopups.Add(key, popup);
            }
           
            if (popup.TryGetComponent(out IGameElement gameElement))
            {
                m_Context.RegisterElement(gameElement);
            }
            popup.transform.SetAsLastSibling();
            return popup;
        }

        public void UnloadWindow(Window popup)
        {
            if (popup.TryGetComponent(out IGameElement gameElement))
            {
                m_Context.UnregisterElement(gameElement);
            }
            popup.gameObject.SetActive(false);
        }

       
    }
}