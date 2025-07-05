using Character.ChangeableValue;
using Common.ChangeableValue;
using Common.FSM;
using Pickable;
using Pickable.Coin;
using Pickable.Medicine;
using UnityEngine;

namespace Character.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Picker _picker;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private ChangeableValueContainer _changeableValueContainer;

        private StateMachine _animatorStateMachine;
        private Health _health;

        public PlayerAnimator PlayerAnimator => _playerAnimator;

        public ChangeableValueContainer ChangeableValueContainer => _changeableValueContainer;

        private void OnEnable()
        {
            _picker.Picking += PickUpHandle;
            _changeableValueContainer.Initialized += CacheChangeableValues;
            CacheChangeableValues();
        }

        private void OnDisable()
        {
            _picker.Picking -= PickUpHandle;
            _changeableValueContainer.Initialized -= CacheChangeableValues;
        }

        private void Update() =>
            _animatorStateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _animatorStateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _animatorStateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine animatorStateMachine) =>
            _animatorStateMachine = animatorStateMachine;

        private void CacheChangeableValues()
        {
            if (_changeableValueContainer.IsInitialized)
            {
                _changeableValueContainer.Initialized -= CacheChangeableValues;
                _health = _changeableValueContainer.Get<Health>();
            }
        }

        private void PickUpHandle(IPickable pickable)
        {
            switch (pickable)
            {
                case Coin coin:
                    _wallet.EarnMoney(coin.Value);
                    break;
                case Medicine medicine:
                    _health.TakeHealing(medicine.Value);
                    break;
            }
        }
    }
}
