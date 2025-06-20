namespace Character
{
    using System;
    using UnityEngine;

    public abstract class AbstractHealth : MonoBehaviour
    {
        private const int MinValue = 0;

        [SerializeField, Min(1)] private int _maxValue = 1;

        private int _value;

        public event Action ValueChanged;

        public int Value
        {
            get
            {
                return _value;
            }

            private set
            {
                _value = Mathf.Clamp(value, MinValue, _maxValue);
                ValueChanged?.Invoke();
            }
        }

        private void Awake() =>
            Value = _maxValue;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException("Damage can't be negative");
            }
            else
            {
                Value -= damage;
            }
        }

        public void TakeHealing(int healing)
        {
            if (healing < 0)
            {
                throw new ArgumentOutOfRangeException("Healing can't be negative");
            }
            else
            {
                Value += healing;
            }
        }
    }
}
