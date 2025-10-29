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
        [SerializeField, Min(1f)] private float _maxHealth;
        [SerializeField] private bool _hasGun;
        
        private StateMachine _stateMachine;

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

        public Health Health { get; private set; }

        private void Awake() =>
            Health = new Health(_maxHealth);

        private void Update() =>
            _stateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _stateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _stateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine stateMachine) =>
            _stateMachine = stateMachine;
    }
}