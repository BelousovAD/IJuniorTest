using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimatorController : MonoBehaviour
{
    private readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    private readonly int IsOnGround = Animator.StringToHash(nameof(IsOnGround));
    private readonly int VelocityHorizontal = Animator.StringToHash(nameof(VelocityHorizontal));
    private readonly int VelocityVertical = Animator.StringToHash(nameof(VelocityVertical));

    [SerializeField] private float _velocityEpsilon = 0.00001f;
    [SerializeField] private PlayerIsOnGroundChecker _playerIsOnGroundChecker;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() =>
        _playerIsOnGroundChecker.IsOnGroundStatusChanged += UpdateIsOnGroundParameter;

    private void OnDisable() =>
        _playerIsOnGroundChecker.IsOnGroundStatusChanged -= UpdateIsOnGroundParameter;

    private void Update()
    {
        _velocity = _rigidbody2D.velocity;
        _animator.SetBool(IsIdle, Mathf.Abs(_velocity.x) <= _velocityEpsilon && Mathf.Abs(_velocity.y) <= _velocityEpsilon);
        _animator.SetFloat(VelocityHorizontal, Mathf.Abs(_velocity.x) > _velocityEpsilon ? Mathf.Abs(_velocity.x) : 0f);
        _animator.SetFloat(VelocityVertical, Mathf.Abs(_velocity.y) > _velocityEpsilon ? _velocity.y : 0f);
    }

    private void UpdateIsOnGroundParameter(bool isOnGround) =>
        _animator.SetBool(IsOnGround, isOnGround);
}
