using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private readonly int IsFalling = Animator.StringToHash(nameof(IsFalling));
    private readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));

    [SerializeField] private PlayerVerticalVelocityReader _playerVerticalVelocityReader;
    [SerializeField] private InputReader _inputReader;

    private Animator _animator;
    private Vector3 _localScale;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerVerticalVelocityReader.FallingStatusChanged += UpdateIsFallingParameter;
        _playerVerticalVelocityReader.JumpingStatusChanged += UpdateIsJumpingParameter;
        _inputReader.HorizontalInputChanged += UpdateLookDirection;
        _inputReader.HorizontalInputChanged += UpdateIsRunningParameter;
    }

    private void OnDisable()
    {
        _playerVerticalVelocityReader.FallingStatusChanged -= UpdateIsFallingParameter;
        _playerVerticalVelocityReader.JumpingStatusChanged -= UpdateIsJumpingParameter;
        _inputReader.HorizontalInputChanged -= UpdateLookDirection;
        _inputReader.HorizontalInputChanged -= UpdateIsRunningParameter;
    }

    private void UpdateIsFallingParameter(bool isFalling) =>
        _animator.SetBool(IsFalling, isFalling);

    private void UpdateIsJumpingParameter(bool isJumping) =>
        _animator.SetBool(IsJumping, isJumping);

    private void UpdateLookDirection(int horizontalInput)
    {
        _localScale = transform.localScale;
        transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * Mathf.Abs(_localScale.x), _localScale.y, _localScale.z);
    }

    private void UpdateIsRunningParameter(int horizontalInput) =>
        _animator.SetBool(IsRunning, horizontalInput != 0);
}
