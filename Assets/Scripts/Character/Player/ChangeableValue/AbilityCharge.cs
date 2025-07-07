using System;
using System.Collections;
using Common.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class AbilityCharge : ChangeableValueComponent<float>
    {
        public const float MaxValue = 1;
        private const float MinValue = 0;
        
        [SerializeField, Min(0)] private float _epsilon = 1e-5f;
        [SerializeField, Min(0)] private float _duration;
        [SerializeField, Min(0)] private float _cooldown;
        
        private float _usageSpeed;
        private float _cooldownSpeed;
               
        public event Action Emptied;
        public event Action Filled;

        public bool IsReady => IsTargetReached(MaxValue);
        
        public override float Value
        {
            get => base.Value;
            protected set => base.Value = Mathf.Clamp(value, MinValue, MaxValue);
        }

        private void Awake()
        {
            Value = MaxValue;
            _usageSpeed = (MaxValue - MinValue) / _duration;
            _cooldownSpeed = (MaxValue - MinValue) / _cooldown;
        }
        
        public void Use() =>
            StartCoroutine(ChangeValueSmoothly(MinValue, _usageSpeed, () => Emptied?.Invoke()));

        public void Recharge() =>
            StartCoroutine(ChangeValueSmoothly(MaxValue, _cooldownSpeed, () => Filled?.Invoke()));

        private IEnumerator ChangeValueSmoothly(float targetValue, float changingSpeed, Action callback = null)
        {
            while (isActiveAndEnabled && IsTargetReached(targetValue) == false)
            {
                Value = Mathf.MoveTowards(Value, targetValue, Time.deltaTime * changingSpeed);

                yield return null;
            }

            Value = targetValue;
            callback?.Invoke();
        }

        private bool IsTargetReached(float targetValue) =>
            Mathf.Abs(targetValue - Value) < _epsilon;
    }
}