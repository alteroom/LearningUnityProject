using System;
using Modules.UISystem.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.Upgrades.HeroUpgrade.View
{
    public class HeroUpgradePopup : Window
    {
        [SerializeField] 
        private TextMeshProUGUI m_Title;
        
        [SerializeField] 
        private TextMeshProUGUI m_PlayerName;
        
        [SerializeField] 
        private TextMeshProUGUI m_Description;
        
        [SerializeField] 
        private TextMeshProUGUI m_LevelInfo;
        
        [SerializeField] 
        private TextMeshProUGUI m_HitPointsInfo;
        
        [SerializeField] 
        private TextMeshProUGUI m_DamageInfo;
        
        [SerializeField] 
        private Button m_ButtonUpgrade;
        
        private IHeroUpgradePresentationModel m_Presenter;

        protected override void OnShow(object args = null)
        {
            if (!(args is IHeroUpgradePresentationModel presenter))
            {
                throw new ArgumentException("HeroUpgradePopup must receive IHeroUpgradePresentationModel");
            }

            m_Presenter = presenter;
            m_Presenter.OnUpgrade += OnUpgrade;
            m_Presenter.OnMoneyChanged += OnMoneyChanged;
            m_Presenter.Start();
            UpdateView();
        }
        protected override void OnHide()
        {
            m_Presenter.OnUpgrade -= OnUpgrade;
            m_Presenter.OnMoneyChanged -= OnMoneyChanged;
            m_Presenter.Stop();
        }
        private void OnMoneyChanged()
        {
            m_ButtonUpgrade.interactable = m_Presenter.CanUpgrade();
        }

        private void UpdateView()
        {
            m_Title.text = m_Presenter.Title;
            m_PlayerName.text = m_Presenter.PlayerName;
            m_Description.text = m_Presenter.Description;
            m_LevelInfo.text = m_Presenter.LevelInfo;
            m_HitPointsInfo.text = m_Presenter.HitPointsInfo;
            m_DamageInfo.text = m_Presenter.DamageInfo;
            m_ButtonUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = m_Presenter.ButtonText;
            m_ButtonUpgrade.interactable = m_Presenter.CanUpgrade();
        }

        private void OnUpgrade()
        {
            UpdateView();
        }

       

       
    }
}
