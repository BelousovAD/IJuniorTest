namespace Input
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public interface IInputReader : IEnable, IDisable
    {
        public ChangeableValue<bool> AttackInput { get; }
        
        public ChangeableValue<Vector2> LookInput { get; }
        
        public ChangeableValue<Vector2> MoveInput { get; }

        public void LockMove();

        public void UnlockMove();
    }
}