namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine.InputSystem;
    using Input = Input;

    public class AttackInput : ChangeableValue<bool>, IEnable, IDisable
    {
        private readonly Input _input;

        public AttackInput(Input input) =>
            _input = input;

        public void Enable()
        {
            _input.Player.Attack.performed += RequestMove;
            _input.Player.Attack.canceled += RequestMove;
        }

        public void Disable()
        {
            _input.Player.Attack.performed -= RequestMove;
            _input.Player.Attack.canceled -= RequestMove;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            Value = context.ReadValue<bool>();
    }
}