namespace Character
{
    using Input;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _cameraRig;
        [SerializeField, Min(0f)] private float _moveSpeed = 1f;
        
        private Vector3 _horizontalVelocity;
        private Vector3 _verticalVelocity;

        private void OnEnable()
        {
            _horizontalVelocity = Vector3.zero;
            _verticalVelocity = Vector3.zero;
            _inputReader.MoveRequested += UpdateHorizontalVelocity;
        }

        private void OnDisable() =>
            _inputReader.MoveRequested -= UpdateHorizontalVelocity;

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

        private void UpdateHorizontalVelocity(Vector2 inputDirection) =>
            _horizontalVelocity = new Vector3(inputDirection.x, 0f, inputDirection.y) * _moveSpeed;
    }
}