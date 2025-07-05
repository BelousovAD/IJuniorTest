using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player
{
    public class AnimationDirectionSetter : MonoBehaviour
    {
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private StandaloneInputReader _inputReader;

        private HorizontalInput _horizontalInput;

        private void Awake() =>
            _horizontalInput = _inputReader.HorizontalInput;

        private void OnEnable() =>
            _horizontalInput.ValueChanged += UpdateLookDirection;

        private void OnDisable() =>
            _horizontalInput.ValueChanged -= UpdateLookDirection;

        private void UpdateLookDirection() =>
            _spriteTransform.localRotation = Quaternion.Euler(0, Mathf.Sign(_horizontalInput.Value) * 90 - 90, 0);
    }
}
