namespace Character.Player
{
    using Common.ChangeableValue;
    using Input;
    using UnityEngine;
    using Zenject;

    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _cameraRig;
        [SerializeField, Min(0f)] private float _moveSpeed = 1f;

        [Inject(Id = "Player")] private IInputReader _inputReader;
        private ChangeableValue<Vector2> _moveInput;
        private Vector3 _horizontalVelocity;
        private Vector3 _verticalVelocity;

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
            if (_horizontalVelocity != Vector3.zero)
            {
                transform.forward = Vector3.ProjectOnPlane(_cameraRig.forward, Vector3.up).normalized;
            }
        }

        private void FixedUpdate()
        {
            _verticalVelocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
            _rigidbody.velocity = transform.rotation * _horizontalVelocity + _verticalVelocity;
        }

        private void UpdateHorizontalVelocity() =>
            _horizontalVelocity = new Vector3(_moveInput.Value.x, 0f, _moveInput.Value.y) * _moveSpeed;
    }
}