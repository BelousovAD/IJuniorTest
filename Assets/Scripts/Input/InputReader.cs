namespace Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class InputReader : MonoBehaviour
    {
        [SerializeField, Min(0f)] private Vector2 _sensitivity = Vector2.one;
        [SerializeField, Min(0f)] private float _deadZone = 0.1f;
        
        private Input _input;
        private Vector2 _mouseDelta;

        public event Action<Vector2> MoveRequested;
        public event Action<Vector2> RotateRequested;
        
        private void Awake() =>
            _input = new Input();

        private void OnEnable()
        {
            _input.Enable();
            _input.Player.Move.performed += RequestMove;
            _input.Player.Move.canceled += RequestMove;
            _input.Player.Look.performed += RequestRotate;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Move.performed -= RequestMove;
            _input.Player.Move.canceled -= RequestMove;
            _input.Player.Look.performed -= RequestRotate;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            MoveRequested?.Invoke(context.ReadValue<Vector2>());
        
        private void RequestRotate(InputAction.CallbackContext context)
        {
            _mouseDelta = context.ReadValue<Vector2>();
            _mouseDelta = new Vector2(_mouseDelta.x * _sensitivity.x, _mouseDelta.y * _sensitivity.y);

            if (Mathf.Abs(_mouseDelta.x) > _deadZone || Mathf.Abs(_mouseDelta.y) > _deadZone)
            {
                RotateRequested?.Invoke(_mouseDelta);
            }
        }
    }
}
