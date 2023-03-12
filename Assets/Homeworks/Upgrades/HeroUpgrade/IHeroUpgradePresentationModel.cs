using System;
using UnityEngine;

namespace Homeworks.Upgrades.HeroUpgrade
{
    public interface IHeroUpgradePresentationModel
    {
        event Action OnUpgrade;
        event Action OnMoneyChanged;
        string Title { get; }
        string PlayerName { get; }
        string Description { get; }
        Sprite Icon { get; }
        string LevelInfo { get; }
        string HitPointsInfo { get; }
        string DamageInfo { get; }
        string ButtonText { get; }

        bool CanUpgrade();
        void OnUpgradeClicked();

        void Start();
        void Stop();
    }
}
