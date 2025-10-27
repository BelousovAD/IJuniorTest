namespace Input
{
    using System;
    using ChangeableValue;

    public class PlayerInputReader : IInputReader, IDisposable
    {
        private readonly Input _input;
        
        public PlayerInputReader()
        {
            _input = new Input();
            AttackInput = new AttackInput(_input);
            LookInput = new LookInput(_input);
            MoveInput = new MoveInput(_input);
            AttackInput.Enable();
            LookInput.Enable();
            MoveInput.Enable();
            _input.Enable();
        }
        
        public AttackInput AttackInput { get; }
        
        public LookInput LookInput { get; }
        
        public MoveInput MoveInput { get; }

        public void Dispose()
        {
            _input.Disable();
            AttackInput.Disable();
            LookInput.Disable();
            MoveInput.Disable();
        }
    }
}
