using Modules.UISystem.Base;
using UnityEngine;

namespace Homeworks.PopupSystem
{
    public class PopupFactory : IWindowFactory<PopupKey, Window>
    {
        private PopupCatalog m_Catalog;

        private Transform m_Container;

        public void Construct(PopupCatalog catalog, Transform container)
        {
            m_Catalog = catalog;
            m_Container = container;
        }
        public Window CreateWindow(PopupKey key)
        {
            var prefab = m_Catalog.GetPrefab(key);
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            var popup = GameObject.Instantiate(prefab, m_Container);
            return popup;
        }
    }
}