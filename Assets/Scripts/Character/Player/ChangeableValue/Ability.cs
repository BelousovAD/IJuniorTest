using Common.ChangeableValue;
using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class Ability : ChangeableValueComponent<bool>
    {
        [SerializeField] private StandaloneInputReader _inputReader;
        [SerializeField] private AbilityCharge _charge;

        private KeyInput _abilityInput;
        
        protected virtual void Awake() =>
            _abilityInput = _inputReader.AbilityInput;

        protected virtual void OnEnable()
        {
            _abilityInput.ValueChanged += Activate;
            _charge.Emptied += Deactivate;
        }

        protected virtual void OnDisable()
        {
            _abilityInput.ValueChanged -= Activate;
            _charge.Emptied -= Deactivate;
        }

        private void Activate()
        {
            if (_charge.IsReady && _abilityInput.Value)
            {
                _charge.Use();
                Value = true;
            }
        }

        private void Deactivate()
        {
            _charge.Recharge();
            Value = false;
        }
    }
}