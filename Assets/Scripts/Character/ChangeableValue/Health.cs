using System;
using Common.ChangeableValue;
using UnityEngine;

namespace Character.ChangeableValue
{
    public class Health : ChangeableValueComponent<float>
    {
        private const float MinValue = 0;

        [SerializeField, Min(1)] private float _maxValue = 1;

        public float MaxValue => _maxValue;

        public override float Value
        {
            get => base.Value;
            protected set => base.Value = Mathf.Clamp(value, MinValue, MaxValue);
        }

        private void Awake() =>
            Value = MaxValue;

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage can't be negative");
            }

            Value -= damage;
        }

        public void TakeHealing(float healing)
        {
            if (healing < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(healing), "Healing can't be negative");
            }

            Value += healing;
        }
    }
}