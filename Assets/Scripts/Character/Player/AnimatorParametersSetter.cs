namespace Character.Player
{
    using UnityEngine;

    public class AnimatorParametersSetter : MonoBehaviour
    {
        private readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        private readonly int IsFalling = Animator.StringToHash(nameof(IsFalling));
        private readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));

        [SerializeField] private Animator _animator;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private VerticalVelocityReader _verticalVelocityReader;


        private void OnEnable()
        {
            _verticalVelocityReader.FallingStatusChanged += UpdateIsFallingParameter;
            _verticalVelocityReader.JumpingStatusChanged += UpdateIsJumpingParameter;
            _inputReader.HorizontalInputChanged += UpdateIsRunningParameter;
        }

        private void OnDisable()
        {
            _verticalVelocityReader.FallingStatusChanged -= UpdateIsFallingParameter;
            _verticalVelocityReader.JumpingStatusChanged -= UpdateIsJumpingParameter;
            _inputReader.HorizontalInputChanged -= UpdateIsRunningParameter;
        }

        private void UpdateIsFallingParameter(bool isFalling) =>
            _animator.SetBool(IsFalling, isFalling);

        private void UpdateIsJumpingParameter(bool isJumping) =>
            _animator.SetBool(IsJumping, isJumping);

        private void UpdateIsRunningParameter(int horizontalInput) =>
            _animator.SetBool(IsRunning, horizontalInput != 0);
    }
}
