using Common.Behaviour;
using Common.ChangeableValue;
using UnityEngine;

namespace Input.ChangeableValue
{
    public class KeyInput : ChangeableValue<bool>, IUpdatable
    {
        private readonly KeyCode _key;

        public KeyInput(KeyCode key) =>
            _key = key;

        public void Update(float deltaTime) =>
            Value = UnityEngine.Input.GetKey(_key);
    }
}