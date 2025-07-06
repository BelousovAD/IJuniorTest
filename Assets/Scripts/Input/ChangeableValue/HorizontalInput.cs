using Common.Behaviour;
using Common.ChangeableValue;
using UnityEngine;

namespace Input.ChangeableValue
{
    public class HorizontalInput : ChangeableValue<int>, IUpdatable
    {
        public const int NeutralValue = 0;
        private const string Horizontal = nameof(Horizontal);

        public void Update(float deltaTime) =>
            Value = Mathf.RoundToInt(UnityEngine.Input.GetAxisRaw(Horizontal));
    }
}