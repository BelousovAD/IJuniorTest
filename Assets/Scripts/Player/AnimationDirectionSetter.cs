namespace Player
{
    using UnityEngine;

    public class AnimationDirectionSetter : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _spriteTransform;

        private Vector3 _localScale;

        private void OnEnable() =>
            _inputReader.HorizontalInputChanged += UpdateLookDirection;

        private void OnDisable() =>
            _inputReader.HorizontalInputChanged -= UpdateLookDirection;

        private void UpdateLookDirection(int horizontalInput)
        {
            _localScale = _spriteTransform.localScale;
            _spriteTransform.localScale = new Vector3(Mathf.Sign(horizontalInput) * Mathf.Abs(_localScale.x), _localScale.y, _localScale.z);
        }
    }
}
