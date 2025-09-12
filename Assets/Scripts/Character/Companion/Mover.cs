namespace Character.Companion
{
    using Input;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private CompanionInput _input;
        [SerializeField, Min(0)] private float _speed;
        [SerializeField] private Transform _lowerPoint;
        [SerializeField, Min(0.1f)] private float _groundCheckRayLength = 0.1f;

        private readonly Vector3 _lowerPointOffset = new(0f, 0.01f, 0f);
        private Rigidbody _rigidbody;
        private bool _isGrounded = true;
        private Vector3 _moveDirection;
        private Vector3 _motion = Vector3.zero;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            _input.MoveInputChanged += UpdateMotion;
            UpdateMotion();
        }

        private void OnDisable() =>
            _input.MoveInputChanged -= UpdateMotion;

        private void FixedUpdate() =>
            _isGrounded = Physics.Raycast(_lowerPoint.position + _lowerPointOffset,
                Vector3.down,
                _groundCheckRayLength);

        private void Update()
        {
            if (_isGrounded)
            {
                Vector3 verticalVelocity = new(0f, _rigidbody.velocity.y, 0f);
                _rigidbody.velocity = _motion + verticalVelocity;
            }
        }

        private void UpdateMotion()
        {
            _moveDirection = new Vector3(_input.MoveInput.x, 0f, _input.MoveInput.y);
            _motion = _moveDirection * _speed;
        }
    }
}