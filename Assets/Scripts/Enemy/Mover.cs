namespace Enemy
{
    using System;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _targetRadius = 0.25f;
        [SerializeField] private float _speed = 0f;
        [SerializeField] private Transform _transformToMove;

        private Transform _target;
        private float _sqrTargetRadius;

        public event Action TargetReached;

        public void SetTarget(Transform target) =>
            _target = target;

        private void Awake() =>
            _sqrTargetRadius = _targetRadius * _targetRadius;

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            _transformToMove.position = Vector2.MoveTowards(_transformToMove.position, _target.position, _speed * Time.deltaTime);

            if (IsTargetReached())
            {
                TargetReached?.Invoke();
            }
        }

        private bool IsTargetReached() =>
            Vector2.SqrMagnitude(_target.position - _transformToMove.position) <= _sqrTargetRadius;
    }
}
