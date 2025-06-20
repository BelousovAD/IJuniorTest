namespace Character.Player
{
    using System;
    using UnityEngine;

    public class Wallet : MonoBehaviour
    {
        private const int MinValue = 0;

        private int _money;

        public event Action MoneyAmountChanged;

        public int Money
        {
            get
            {
                return _money;
            }

            private set
            {
                _money = value > MinValue ? value : MinValue;
                MoneyAmountChanged?.Invoke();
            }
        }

        public void EarnMoney(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount can't be negative");
            }
            else
            {
                Money += amount;
            }
        }

        public bool TrySpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
