using System;
using System.Collections;
using Common.ChangeableValue;
using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class VampireAbility : ChangeableValueComponent<float>
    {
        public const float MaxValue = 1;
        private const float MinValue = 0;
        
        [SerializeField, Min(0)] private float _epsilon = 1e-5f;
        [SerializeField, Min(0)] private float _duration;
        [SerializeField, Min(0)] private float _cooldown;
        [SerializeField] private StandaloneInputReader _inputReader;
        
        private float _usageSpeed;
        private float _cooldownSpeed;
        private KeyInput _abilityInput;

        public event Action Ended;
        public event Action Recharged;
        
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
            _abilityInput = _inputReader.AbilityInput;
        }

        private void OnEnable() =>
            _abilityInput.ValueChanged += Activate;

        private void OnDisable() =>
            _abilityInput.ValueChanged -= Activate;

        private void Activate()
        {
            if (IsTargetReached(MaxValue) && _abilityInput.Value)
            {
                StartCoroutine(ChangeValueSmoothly(MinValue, _usageSpeed, () =>
                {
                    Ended?.Invoke();
                    Recharge();
                }));
            }
        }

        private void Recharge() =>
            StartCoroutine(ChangeValueSmoothly(MaxValue, _cooldownSpeed, () => Recharged?.Invoke()));

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
