using Character.Player.ChangeableValue;
using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpVelocity = 5f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private IsOnGround _isOnGround;
        [SerializeField] private StandaloneInputReader _inputReader;

        private HorizontalInput _horizontalInput;
        private JumpInput _jumpInput;
        private float _horizontalVelocity;

        private void Awake()
        {
            _horizontalInput = _inputReader.HorizontalInput;
            _jumpInput = _inputReader.JumpInput;
        }

        private void OnEnable()
        {
            _horizontalInput.ValueChanged += UpdateHorizontalVelocity;
            _jumpInput.ValueChanged += ApplyJump;
        }

        private void OnDisable()
        {
            _horizontalInput.ValueChanged -= UpdateHorizontalVelocity;
            _jumpInput.ValueChanged -= ApplyJump;
        }

        private void FixedUpdate() =>
            _rigidbody2D.velocity = new Vector2(_horizontalVelocity, _rigidbody2D.velocity.y);

        private void UpdateHorizontalVelocity() =>
            _horizontalVelocity = _horizontalInput.Value * _speed;

        private void ApplyJump()
        {
            if (_jumpInput.Value && _isOnGround.Value)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
            }
        }
    }
}
