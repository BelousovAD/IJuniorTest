using Common.Behaviour;
using Common.ChangeableValue;

namespace Input.ChangeableValue
{
    public class FireInput : ChangeableValue<bool>, IUpdatable
    {
        private const string Fire1 = nameof(Fire1);
        
        public void Update(float deltaTime) =>
            Value = UnityEngine.Input.GetButton(Fire1);
    }
}