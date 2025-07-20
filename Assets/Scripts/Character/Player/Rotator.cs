namespace Character.Player
{
    using Input;
    using Input.ChangeableValue;
    using UnityEngine;

    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _speed;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private StandaloneInputReader _inputReader;
        
        private JumpInput _jumpInput;
        private Quaternion _minRotation;
        private Quaternion _maxRotation;

        private void Awake()
        {
            _jumpInput = _inputReader.JumpInput;
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        }

        private void OnEnable() =>
            _jumpInput.ValueChanged += ApplyJump;

        private void OnDisable() =>
            _jumpInput.ValueChanged -= ApplyJump;

        private void Update() =>
            _rectTransform.rotation = Quaternion.Lerp(
                _rectTransform.rotation,
                _minRotation,
                _speed * Time.deltaTime);

        private void ApplyJump()
        {
            if (_jumpInput.Value)
            {
                _rectTransform.rotation = _maxRotation;
            }
        }
    }
}