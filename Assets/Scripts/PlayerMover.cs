using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpVelocity = 5f;

    private Rigidbody2D _rigidbody2D;
    int _horizontalInput;
    bool _isJumpRequested;

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _horizontalInput = Mathf.RoundToInt(Input.GetAxisRaw(Horizontal));

        if (_isJumpRequested == false)
        {
            _isJumpRequested = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _rigidbody2D.velocity;
        Vector3 localScale = transform.localScale;
        _rigidbody2D.velocity = new Vector2(_horizontalInput * _speed, _isJumpRequested ? _jumpVelocity : velocity.y);
        transform.localScale = new Vector3(Mathf.Sign(_horizontalInput), localScale.y, localScale.z);
        _isJumpRequested = false;
    }
}
