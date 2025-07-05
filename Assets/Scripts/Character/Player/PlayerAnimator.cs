using UnityEngine;

namespace Character.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayIdle() =>
            _animator.SetTrigger(AnimatorParameters.Player.Idle);

        public void PlayJump() =>
            _animator.SetTrigger(AnimatorParameters.Player.Jump);

        public void PlayFall() =>
            _animator.SetTrigger(AnimatorParameters.Player.Fall);

        public void PlayMove() =>
            _animator.SetTrigger(AnimatorParameters.Player.Move);
    }
}
