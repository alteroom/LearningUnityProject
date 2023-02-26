using System;

namespace Modules.MoneySystem
{
    public class MoneyStorage
    {
        public event Action<int> OnMoneyChanged;

        public int Money => m_Money;
        
        private int m_Money;

        public void Setup(int money)
        {
            m_Money = money;
        }

        public void Add(int money)
        {
            if (money > 0)
            {
                m_Money += money;
                OnMoneyChanged?.Invoke(m_Money);
            }
        }

        public bool CanSpend(int money)
        {
            return m_Money >= money;
        }
        public void Spend(int money)
        {
            if (CanSpend(money))
            {
                m_Money -= money;
                OnMoneyChanged?.Invoke(m_Money);
            }
        }
    }
}