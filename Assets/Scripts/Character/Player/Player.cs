using Common.FSM;
using UnityEngine;

namespace Character.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;

        private StateMachine _animatorStateMachine;

        public PlayerAnimator PlayerAnimator => _playerAnimator;

        private void Update() =>
            _animatorStateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _animatorStateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _animatorStateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine animatorStateMachine) =>
            _animatorStateMachine = animatorStateMachine;
    }
}
