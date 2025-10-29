namespace Character
{
    using Common.ChangeableValue;
    using Input;
    using UnityEngine;
    using Zenject;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField, Min(0f)] private float _moveSpeed = 1f;

        private ChangeableValue<Vector2> _moveInput;
        private Vector3 _horizontalVelocity;
        private Vector3 _verticalVelocity;
        private Vector3 _moveInputDirection;

        [Inject]
        public void Initialize(IInputReader inputReader)
        {
            if (_moveInput is not null)
            {
                _moveInput.ValueChanged -= UpdateHorizontalVelocity;
            }
            
            _moveInput = inputReader.MoveInput;

            if (isActiveAndEnabled)
            {
                _moveInput.ValueChanged += UpdateHorizontalVelocity;
            }
        }

        private void OnEnable()
        {
            _horizontalVelocity = Vector3.zero;
            _verticalVelocity = Vector3.zero;

            if (_moveInput is not null)
            {
                _moveInput.ValueChanged += UpdateHorizontalVelocity;
            }
        }

        private void OnDisable() =>
            _moveInput.ValueChanged -= UpdateHorizontalVelocity;
        
        protected virtual Quaternion RotateForward() =>
            Quaternion.identity;

        private void Update()
        {
            if (_moveInputDirection != Vector3.zero)
            {
                _rigidbody.transform.forward = RotateForward() * _moveInputDirection;
            }
        }

        private void FixedUpdate()
        {
            if (_rigidbody.isKinematic == false)
            {
                _verticalVelocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
                _rigidbody.velocity = transform.rotation * _horizontalVelocity + _verticalVelocity;
            }
        }

        private void UpdateHorizontalVelocity()
        {
            if (_moveInput.Value != Vector2.zero)
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