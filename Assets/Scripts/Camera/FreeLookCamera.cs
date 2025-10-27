namespace Camera
{
    using Common.ChangeableValue;
    using Input;
    using UnityEngine;
    using Zenject;

    public class FreeLookCamera : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _target;
        [SerializeField, Min(0.001f)] private float _sphereRadius = 0.1f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField, Min(0f)] private float _preferredDistance = 2f;
        [SerializeField, Range(-89f, 0f)] private float _minVerticalAngle = -89f;
        [SerializeField, Range(1f, 89f)] private float _maxVerticalAngle = 89f;

        [Inject(Id = "Player")] private IInputReader _inputReader;
        private ChangeableValue<Vector2> _lookInput;
        private float _verticalAngle;
        
        public float HorizontalAngle { get; private set; }

        private void Awake() =>
            _lookInput = _inputReader.LookInput;

        private void OnEnable() =>
            _lookInput.ValueChanged += Rotate;

        private void OnDisable() =>
            _lookInput.ValueChanged -= Rotate;

        private void LateUpdate()
        {
            transform.position = _target.position;
            _camera.localPosition = Physics.Raycast(
                transform.position,
                -transform.forward,
                out RaycastHit hit,
                _preferredDistance,
                _layerMask)
                ? new Vector3(0f, 0f, -hit.distance + _sphereRadius)
                : new Vector3(0f, 0f, -_preferredDistance);
        }

        private void Rotate()
        {
            HorizontalAngle += _lookInput.Value.x;
            HorizontalAngle %= 360;
            _verticalAngle -= _lookInput.Value.y;
            _verticalAngle = Mathf.Clamp(_verticalAngle, _minVerticalAngle, _maxVerticalAngle);
            transform.rotation = Quaternion.Euler(_verticalAngle, HorizontalAngle, 0f);
        }
    }
}