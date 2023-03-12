using System;
using Modules.MoneySystem;
using UnityEngine;

namespace Homeworks.Upgrades.HeroUpgrade
{
    public class HeroUpgradePresentationModel : IHeroUpgradePresentationModel
    {
        public event Action OnUpgrade;
        public event Action OnMoneyChanged;

        private readonly IUpgradeSystem<Upgrade> m_UpgradeSystem;
        private readonly MoneyStorage m_MoneyStorage;
        private readonly PlayerInfo m_PlayerInfo;
        private Upgrade m_Upgrade;
        
        public string Title => "Upgrade";
        public string PlayerName => m_PlayerInfo.Name;
        public string Description => m_PlayerInfo.Description;
        public Sprite Icon => m_PlayerInfo.Icon;
        public string LevelInfo => $"Level: {m_Upgrade.Level}/{m_Upgrade.MaxLevel}";
        public string HitPointsInfo => $"Hit Points: {m_Upgrade.HitPoints}/{m_Upgrade.MaxHitPoints}";
        public string DamageInfo => $"Damage: {m_Upgrade.Damage}";
        public string ButtonText => "Upgrade";

        public HeroUpgradePresentationModel(IUpgradeSystem<Upgrade> upgradeSystem, MoneyStorage moneyStorage, PlayerInfo playerInfo)
        {
            m_UpgradeSystem = upgradeSystem;
            m_MoneyStorage = moneyStorage;
            m_PlayerInfo = playerInfo;

            m_Upgrade = m_UpgradeSystem.CurrentUpgrade;
        }
        
        public bool CanUpgrade()
        {
            return m_UpgradeSystem.CanUpgrade();
        }

        public void OnUpgradeClicked()
        {
            m_UpgradeSystem.Upgrade();
        }
        
        void IHeroUpgradePresentationModel.Start()
        {
            m_UpgradeSystem.OnUpgrade += UpgradeSystemOnUpgrade;
            m_MoneyStorage.OnMoneyChanged += MoneyStorageOnMoneyChanged;
        }

        void IHeroUpgradePresentationModel.Stop()
        {
            m_UpgradeSystem.OnUpgrade -= UpgradeSystemOnUpgrade;
            m_MoneyStorage.OnMoneyChanged -= MoneyStorageOnMoneyChanged;
        }
        
        private void UpgradeSystemOnUpgrade()
        {
            OnUpgrade?.Invoke();
        }
        private void MoneyStorageOnMoneyChanged(int obj)
        {
            OnMoneyChanged?.Invoke();
        }
    }
}