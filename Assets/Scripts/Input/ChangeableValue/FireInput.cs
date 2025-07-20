namespace Input.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public class FireInput : ChangeableValue<bool>, IUpdatable
    {
        private const string Fire1 = nameof(Fire1);
        
        public void Update(float deltaTime) =>
            Value = Input.GetButton(Fire1);
    }
}