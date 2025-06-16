using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalVelocity;

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void OnEnable()
    {
        _inputReader.HorizontalInputChanged += UpdateHorizontalVelocity;
        _inputReader.JumpRequested += UpdateVerticalVelocity;
    }

    private void OnDisable()
    {
        _inputReader.HorizontalInputChanged -= UpdateHorizontalVelocity;
        _inputReader.JumpRequested -= UpdateVerticalVelocity;
    }

    private void FixedUpdate() =>
        _rigidbody2D.velocity = new Vector2(_horizontalVelocity, _rigidbody2D.velocity.y);

    private void UpdateHorizontalVelocity(int horizontalInput) =>
        _horizontalVelocity = horizontalInput * _speed;

    private void UpdateVerticalVelocity() =>
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
}
