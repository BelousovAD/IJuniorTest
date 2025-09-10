namespace Character.Player
{
    using Input;
    using UnityEngine;

    public class Rotator : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        
        private Vector3 _lookDirection;

        private void OnEnable() =>
            _inputReader.MoveInputChanged += UpdateLook;

        private void OnDisable() =>
            _inputReader.MoveInputChanged -= UpdateLook;

        private void UpdateLook()
        {
            _lookDirection = new Vector3(_inputReader.MoveInput.x, 0f, _inputReader.MoveInput.y);

            if (_lookDirection != Vector3.zero)
            {
                transform.forward = _lookDirection;
            }
        }
    }
}