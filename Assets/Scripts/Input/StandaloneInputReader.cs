namespace Input
{
    using ChangeableValue;
    using UnityEngine;

    public class StandaloneInputReader : MonoBehaviour
    {
        public FireInput FireInput { get; } = new();
        public JumpInput JumpInput { get; } = new();

        private void Update()
        {
            FireInput.Update(Time.deltaTime);
            JumpInput.Update(Time.deltaTime);
        }
    }
}
