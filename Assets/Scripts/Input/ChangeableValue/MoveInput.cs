namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Input = Input;

    public class MoveInput : ChangeableValue<Vector2>, IEnable, IDisable
    {
        public static readonly Vector2 NeutralValue = Vector2.zero;
        
        private readonly Input _input;

        public MoveInput(Input input) =>
            _input = input;

        public void Enable()
        {
            _input.Player.Move.performed += RequestMove;
            _input.Player.Move.canceled += RequestMove;
        }

        public void Disable()
        {
            _input.Player.Move.performed -= RequestMove;
            _input.Player.Move.canceled -= RequestMove;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            Value = context.ReadValue<Vector2>();
    }
}