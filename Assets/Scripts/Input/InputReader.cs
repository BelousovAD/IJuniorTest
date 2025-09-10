namespace Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using PlayerInput = PlayerInput;

    public class InputReader : MonoBehaviour
    {
        private PlayerInput _input;
        private Vector2 _moveInput = Vector2.zero;

        public event Action MoveInputChanged;

        public Vector2 MoveInput
        {
            get
            {
                return _moveInput;
            }

            private set
            {
                _moveInput = value;
                MoveInputChanged?.Invoke();
            }
        }

        private void Awake() =>
            _input = new PlayerInput();

        private void OnEnable()
        {
            _input.Player.Move.performed += UpdateMovementInput;
            _input.Player.Move.canceled += UpdateMovementInput;
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Player.Move.performed -= UpdateMovementInput;
            _input.Player.Move.canceled -= UpdateMovementInput;
            _input.Disable();
        }

        private void UpdateMovementInput(InputAction.CallbackContext context) =>
            MoveInput = context.ReadValue<Vector2>();
    }
}