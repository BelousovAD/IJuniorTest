namespace Character
{
    using System;
    using ChangeableValue;
    using Common.FSM;
    using Common.Spawn;
    using UnityEngine;

    public class Character : PooledComponent
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private bool _hasGun;
        
        private StateMachine _stateMachine;

        public event Action Initialized;
        public event Action WeaponChanged;

        public CharacterAnimator Animator => _animator;

        public bool HasGun
        {
            get
            {
                return _hasGun;
            }

            private set
            {
                if (value != _hasGun)
                {
                    _hasGun = value;
                    WeaponChanged?.Invoke();
                }
            }
        }

        public Health Health { get; protected set; }

        public IStateSwitcher StateSwitcher => _stateMachine;

        protected virtual void OnEnable() =>
            Health.ValueChanged += Die;

        private void OnDisable() =>
            Health.ValueChanged -= Die;

        private void Update() =>
            _stateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _stateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _stateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            Initialized?.Invoke();
        }

        protected virtual void Die()
        {
            if (Health.Value <= 0)
            {
                Release();
            }
        }
    }
}