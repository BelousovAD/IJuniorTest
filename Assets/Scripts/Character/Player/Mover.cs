namespace Character.Player
{
    using Input;
    using Input.ChangeableValue;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _jumpVelocity = 5f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private StandaloneInputReader _inputReader;

        private JumpInput _jumpInput;

        private void Awake() =>
            _jumpInput = _inputReader.JumpInput;

        private void OnEnable() =>
            _jumpInput.ValueChanged += ApplyJump;

        private void OnDisable() =>
            _jumpInput.ValueChanged -= ApplyJump;

        private void ApplyJump()
        {
            if (_jumpInput.Value)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
            }
        }
    }
}
