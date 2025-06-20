namespace Character.Player
{
    using UnityEngine;

    public class AnimationDirectionSetter : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _spriteTransform;

        private Quaternion _localRotation;

        private void OnEnable() =>
            _inputReader.HorizontalInputChanged += UpdateLookDirection;

        private void OnDisable() =>
            _inputReader.HorizontalInputChanged -= UpdateLookDirection;

        private void UpdateLookDirection(int horizontalInput)
        {
            _localRotation = _spriteTransform.localRotation;
            _spriteTransform.localRotation = Quaternion.Euler(0, Mathf.Sign(horizontalInput) * 90 - 90, 0);
        }
    }
}
