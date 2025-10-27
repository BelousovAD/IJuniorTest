namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Input = Input;

    public class LookInput : ChangeableValue<Vector2>, IEnable, IDisable
    {
        private readonly Input _input;

        public LookInput(Input input) =>
            _input = input;

        public void Enable()
        {
            _input.Player.Look.performed += RequestLook;
            _input.Player.Look.canceled += RequestLook;
        }

        public void Disable()
        {
            _input.Player.Look.performed -= RequestLook;
            _input.Player.Look.canceled -= RequestLook;
        }

        private void RequestLook(InputAction.CallbackContext context) =>
            Value = context.ReadValue<Vector2>();
    }
}