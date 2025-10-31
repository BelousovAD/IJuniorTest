namespace Input
{
    using UnityEngine;
    using Zenject;

    public class CursorLocker : MonoBehaviour
    {
        [SerializeField] private bool _isLocked;
        [SerializeField] private bool _setOnEnable;
        [SerializeField] private bool _setOnDisable;
        
        private IInputReader _inputReader;

        [Inject]
        private void Initialize(IInputReader inputReader) =>
            _inputReader = inputReader;

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

        private void UpdateCursorMode()
        {
            if (_isLocked)
            {
                _inputReader.Enable();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                _inputReader.Disable();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}