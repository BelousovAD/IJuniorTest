namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public class JumpInput : ChangeableValue<bool>, IUpdatable
    {
        private const string Jump = nameof(Jump);
        
        public void Update(float deltaTime) =>
            Value = Input.GetButton(Jump);
    }
}