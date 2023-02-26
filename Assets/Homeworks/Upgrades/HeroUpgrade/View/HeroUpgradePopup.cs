using System;
using Modules.UISystem.Base;

namespace Homeworks.Upgrades.HeroUpgrade.View
{
    public class HeroUpgradePopup : Window
    {
        private IHeroUpgradePresentationModel m_Presenter;

        protected override void OnShow(object args = null)
        {
            if (!(args is IHeroUpgradePresentationModel presenter))
            {
                throw new ArgumentException("HeroUpgradePopup must receive IHeroUpgradePresentationModel");
            }

            m_Presenter = presenter;
        }

        protected override void OnHide()
        {
        
        }

       
    }
}
