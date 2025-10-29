namespace Input
{
    using Common.ChangeableValue;
    using UnityEngine;

    public interface IInputReader
    {
        public ChangeableValue<bool> AttackInput { get; }
        
        public ChangeableValue<Vector2> LookInput { get; }
        
        public ChangeableValue<Vector2> MoveInput { get; }

        public void LockMove();

        public void UnlockMove();
    }
}