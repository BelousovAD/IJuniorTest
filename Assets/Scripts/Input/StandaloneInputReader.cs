using Input.ChangeableValue;
using UnityEngine;

namespace Input
{
    public class StandaloneInputReader : MonoBehaviour
    {
        public HorizontalInput HorizontalInput { get; } = new();
        public JumpInput JumpInput { get; } = new();

        private void Update()
        {
            HorizontalInput.Update(Time.deltaTime);
            JumpInput.Update(Time.deltaTime);
        }
    }
}
