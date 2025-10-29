namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Input = Input;

    public class MoveInput : ChangeableValue<Vector2>, IEnable, IDisable
    {
        private readonly Input _input;
        private bool _isActive;

        public MoveInput(Input input) =>
            _input = input;

        public void Enable()
        {
            if (_isActive == false)
            {
                _input.Player.Move.performed += RequestMove;
                _input.Player.Move.canceled += RequestMove;
                Value = _input.Player.Move.ReadValue<Vector2>();
                _isActive = true;
            }
        }

        public void Disable()
        {
            if (_isActive)
            {
                _input.Player.Move.performed -= RequestMove;
                _input.Player.Move.canceled -= RequestMove;
                Value = Vector2.zero;
                _isActive = false;
            }
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            Value = context.ReadValue<Vector2>();
    }
}