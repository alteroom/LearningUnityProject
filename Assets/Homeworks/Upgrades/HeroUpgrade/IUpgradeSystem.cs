using System;

namespace Homeworks.Upgrades.HeroUpgrade
{
    public interface IUpgradeSystem<out T>
    {
        event Action OnUpgrade;
        
        T CurrentUpgrade { get; }

        bool CanUpgrade();

        void Upgrade();
        
    }
}