namespace Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using PlayerInput = PlayerInput;

    public class CompanionInput : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField, Min(0)] private float _radiusOfTarget;
        
        private Vector2 _moveInput = Vector2.zero;
        private float _sqrRadiusOfTarget;

        public event Action MoveInputChanged;

        public Vector2 MoveInput
        {
            get
            {
                return _moveInput;
            }

            private set
            {
                _moveInput = value;
                MoveInputChanged?.Invoke();
            }
        }

        private void Awake() =>
            _sqrRadiusOfTarget = _radiusOfTarget * _radiusOfTarget;
        
        private void Update() =>
            UpdateMovementInput();
        
        private bool IsTargetReached() =>
            Vector3.SqrMagnitude(_target.position - transform.position) < _sqrRadiusOfTarget;

        private void UpdateMovementInput()
        {
            if (IsTargetReached())
            {
                MoveInput = Vector2.zero;
            }
            else
            {
                Vector3 requestedDirection = Vector3.ProjectOnPlane(_target.position - transform.position,
                Vector3.up).normalized;
                MoveInput = new Vector2(requestedDirection.x, requestedDirection.z);
            }
        }
    }
}