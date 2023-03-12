using System;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using Modules.MoneySystem;
using UnityEngine;

namespace Homeworks.Upgrades.HeroUpgrade
{
    public class UpgradeSystem : MonoBehaviour, IUpgradeSystem<Upgrade>, IGameConstructElement
    {
        public event Action OnUpgrade;
        
        [SerializeField] 
        private UpgradeCatalog m_Catalog;
        
        private MoneyStorage m_MoneyStorage;

        private int m_CurrentUpgradeIndex;
        
        private int m_MaxUpgradeIndex;

        private Upgrade[] m_Upgrades;
        
        public void ConstructGame(IGameContext context)
        {
            m_MoneyStorage = context.GetService<MoneyStorage>();
            if (m_MoneyStorage == null)
            {
                throw new NullReferenceException("MoneyStorage can not be null");
            }
            if (m_Catalog == null)
            {
                throw new NullReferenceException("Catalog can not be null");
            }
            // TODO load and save index
            m_CurrentUpgradeIndex = 0;
            m_Upgrades = m_Catalog.Upgrades;
            m_MaxUpgradeIndex = m_Upgrades.Length - 1;
            
        }

        public Upgrade CurrentUpgrade {
            get
            {
                if (m_CurrentUpgradeIndex <= m_MaxUpgradeIndex)
                {
                    return m_Upgrades[m_CurrentUpgradeIndex];
                }
                return  m_Upgrades[m_MaxUpgradeIndex];
            }
        }
        public bool CanUpgrade()
        {
            if (m_CurrentUpgradeIndex > m_MaxUpgradeIndex)
            {
                return false;
            }
            return m_MoneyStorage.Money >= CurrentUpgrade.Cost;
        }

        public void Upgrade()
        {
            if (!CanUpgrade()) return;
            
            m_MoneyStorage.Spend(CurrentUpgrade.Cost);
            m_CurrentUpgradeIndex++;
            OnUpgrade?.Invoke();
        }
    }
}