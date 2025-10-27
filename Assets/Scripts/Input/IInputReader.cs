namespace Input
{
    using ChangeableValue;

    public interface IInputReader
    {
        public AttackInput AttackInput { get; }
        
        public LookInput LookInput { get; }
        
        public MoveInput MoveInput { get; }
    }
}