using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;

namespace Homeworks.PopupSystem
{
    public class PopupSystemInstaller : MonoBehaviour, IGameConstructElement
    {
        [SerializeField] 
        private Transform m_Container;

        [SerializeField] 
        private PopupCatalog m_Catalog;
        
        private readonly PopupFactory m_Factory = new();
        private readonly PopupManager m_Manager = new();
        private readonly PopupSupplier m_Supplier = new();
        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            m_Factory.Construct(m_Catalog, m_Container);
            m_Manager.Construct(m_Supplier);
            m_Supplier.Construct(context, m_Factory);
        }
    }
}