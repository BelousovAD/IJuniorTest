namespace Input
{
    using System;
    using ChangeableValue;
    using Common.ChangeableValue;
    using UnityEngine;

    public class PlayerInputReader : IInputReader, IDisposable
    {
        private readonly Input _input;
        private readonly AttackInput _attackInput;
        private readonly LookInput _lookInput;
        private readonly MoveInput _moveInput;
        
        public PlayerInputReader()
        {
            _input = new Input();
            _attackInput = new AttackInput(_input);
            _lookInput = new LookInput(_input);
            _moveInput = new MoveInput(_input);
            _attackInput.Enable();
            _lookInput.Enable();
            _moveInput.Enable();
            _input.Enable();
        }
        
        public ChangeableValue<bool> AttackInput => _attackInput;

        public ChangeableValue<Vector2> LookInput => _lookInput;

        public ChangeableValue<Vector2> MoveInput => _moveInput;

        public void Dispose()
        {
            _input.Disable();
            _attackInput.Disable();
            _lookInput.Disable();
            _moveInput.Disable();
        }
    }
}
