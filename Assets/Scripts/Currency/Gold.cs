namespace Currency
{
    using System;
    using UnityEngine;

    public class Gold : MonoBehaviour
    {
        private const int MinValue = 0;
        private const int MaxValue = int.MaxValue;

        private int _value;

        public event Action Changed;
        public event Action Increased;

        public int Value
        {
            get
            {
                return _value;
            }

            private set
            {
                int oldValue = _value;
                _value = Mathf.Clamp(value, MinValue, MaxValue);
                Changed?.Invoke();

                if (oldValue < _value)
                {
                    Increased?.Invoke();
                }
            }
        }

        public void Earn(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            Value += amount;
        }

        public bool TrySpend(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            if (Value < amount)
            {
                return false;
            }
            
            Value -= amount;
            
            return true;
        }
    }
}