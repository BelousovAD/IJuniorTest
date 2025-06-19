namespace Player
{
    using UnityEngine;

    public class Wallet : MonoBehaviour
    {
        private uint _currency;

        public void EarnCurrency(uint amount) =>
            _currency += amount;

        public bool TrySpendCurrency(uint amount)
        {
            if (_currency >= amount)
            {
                _currency -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
