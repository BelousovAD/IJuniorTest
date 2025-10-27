namespace Character.Player
{
    using Camera;
    using Common.ChangeableValue;
    using Input;
    using Input.ChangeableValue;
    using UnityEngine;
    using Zenject;

    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private FreeLookCamera _freeLookCamera;
        [SerializeField, Min(0f)] private float _moveSpeed = 1f;

        [Inject(Id = "Player")] private IInputReader _inputReader;
        private ChangeableValue<Vector2> _moveInput;
        private Vector3 _horizontalVelocity;
        private Vector3 _verticalVelocity;
        private Vector3 _moveInputDirection;

        private void Awake() =>
            _moveInput = _inputReader.MoveInput;

        private void OnEnable()
        {
            _horizontalVelocity = Vector3.zero;
            _verticalVelocity = Vector3.zero;
            _moveInput.ValueChanged += UpdateHorizontalVelocity;
        }

        private void OnDisable() =>
            _moveInput.ValueChanged -= UpdateHorizontalVelocity;

        private void Update()
        {
            if (_moveInputDirection != Vector3.zero)
            {
                _rigidbody.transform.forward =
                    Quaternion.AngleAxis(_freeLookCamera.HorizontalAngle, Vector3.up) * _moveInputDirection;
            }
        }

        private void FixedUpdate()
        {
            _verticalVelocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
            _rigidbody.velocity = transform.rotation * _horizontalVelocity + _verticalVelocity;
        }

        private void UpdateHorizontalVelocity()
        {
            if (_moveInput.Value != MoveInput.NeutralValue)
            {
                _moveInputDirection = new Vector3(_moveInput.Value.x, 0f, _moveInput.Value.y);
                _horizontalVelocity = Vector3.forward * _moveSpeed;
            }
            else
            {
                _moveInputDirection = Vector3.zero;
                _horizontalVelocity = Vector3.zero;
            }
        }
    }
}