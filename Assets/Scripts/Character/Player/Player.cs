namespace Character.Player
{
    using System;
    using Common.FSM;
    using UnityEngine;
    using Weapon.Bullet;

    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;

        private StateMachine _animatorStateMachine;

        public event Action Died;

        public PlayerAnimator PlayerAnimator => _playerAnimator;

        private void Update() =>
            _animatorStateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _animatorStateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _animatorStateMachine?.FixedUpdate(Time.fixedTime);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Bullet>(out _))
            {
                Died?.Invoke();
            }
        }

        public void Initialize(StateMachine animatorStateMachine) =>
            _animatorStateMachine = animatorStateMachine;
    }
}
