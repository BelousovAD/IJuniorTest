namespace Camera
{
    using Input;
    using UnityEngine;

    public class FreeLookCamera : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _anchor;
        [SerializeField, Range(-89f, 0f)] private float _minVerticalAngle = -89f;
        [SerializeField, Range(1f, 89f)] private float _maxVerticalAngle = 89f;

        private float _horizontalAngle;
        private float _verticalAngle;

        private void OnEnable() =>
            _inputReader.RotateRequested += Rotate;

        private void OnDisable() =>
            _inputReader.RotateRequested -= Rotate;

        private void LateUpdate() =>
            transform.position = _anchor.position;

        private void Rotate(Vector2 delta)
        {
            _horizontalAngle += delta.x;
            _verticalAngle -= delta.y;
            _verticalAngle = Mathf.Clamp(_verticalAngle, _minVerticalAngle, _maxVerticalAngle);
            transform.rotation = Quaternion.Euler(_verticalAngle, _horizontalAngle, 0f);
        }
    }
}