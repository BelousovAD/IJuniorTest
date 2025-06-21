namespace Character.Player
{
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpVelocity = 5f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private GroundDetector _groundDetector;

        private float _horizontalVelocity;

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

        private void UpdateVerticalVelocity()
        {
            if (_groundDetector.IsOnGround)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
            }
        }
    }
}
