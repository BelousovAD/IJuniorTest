using Input.ChangeableValue;
using UnityEngine;

namespace Input
{
    public class StandaloneInputReader : MonoBehaviour
    {
        public JumpInput JumpInput { get; } = new();

        private void Update() =>
            JumpInput.Update(Time.deltaTime);
    }
}
