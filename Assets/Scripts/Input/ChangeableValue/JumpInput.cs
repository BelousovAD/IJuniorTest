using Common.Behaviour;
using Common.ChangeableValue;

namespace Input.ChangeableValue
{
    public class JumpInput : ChangeableValue<bool>, IUpdatable
    {
        private const string Jump = nameof(Jump);
        
        public void Update(float deltaTime) =>
            Value = UnityEngine.Input.GetButton(Jump);
    }
}