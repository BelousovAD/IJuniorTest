namespace Input
{
    using UnityEngine;

    public class CursorLocker : MonoBehaviour
    {
        [SerializeField] private bool _isLocked;
        [SerializeField] private bool _setOnEnable;
        [SerializeField] private bool _setOnDisable;

        private void OnEnable()
        {
            if (_setOnEnable)
            {
                UpdateCursorMode();
            }
        }

        private void OnDisable()
        {
            if (_setOnDisable)
            {
                UpdateCursorMode();
            }
        }

        private void UpdateCursorMode() =>
            Cursor.lockState = _isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}