using System;
using Common.ChangeableValue;
using UnityEngine;

namespace Character.ChangeableValue
{
    public class Health : ChangeableValueComponent<int>
    {
        private const int MinValue = 0;

        [SerializeField, Min(1)] private int _maxValue = 1;

        public int MaxValue => _maxValue;

        public override int Value
        {
            get => base.Value;
            protected set => base.Value = Mathf.Clamp(value, MinValue, MaxValue);
        }

        private void Awake() =>
            Value = MaxValue;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage can't be negative");
            }

            Value -= damage;
        }

        public void TakeHealing(int healing)
        {
            if (healing < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(healing), "Healing can't be negative");
            }

            Value += healing;
        }
    }
}