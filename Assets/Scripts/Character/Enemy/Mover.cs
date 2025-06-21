namespace Character.Enemy
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _targetRadius = 0.25f;
        [SerializeField] private float _speed = 0f;
        [SerializeField] private Transform _transformToMove;

        private Transform _target;
        private float _sqrTargetRadius;
        private Coroutine _moving;

        public event Action TargetReached;

        private void Awake() =>
            _sqrTargetRadius = _targetRadius * _targetRadius;

        private void OnEnable()
        {
            if (_target != null && _moving == null)
            {
                _moving = StartCoroutine(Moving());
            }
        }

        private void OnDisable()
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
                _moving = null;
            }
        }

        public void MoveTo(Transform target)
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }

            _target = target;

            if (_target != null)
            {
                _moving = StartCoroutine(Moving());
            }
        }

        private IEnumerator Moving()
        {
            while (IsTargetReached() == false)
            {
                yield return null;

                _transformToMove.position = Vector2.MoveTowards(_transformToMove.position, _target.position, _speed * Time.deltaTime);
            }

            _target = null;
            TargetReached?.Invoke();
        }

        private bool IsTargetReached() =>
            Vector2.SqrMagnitude(_target.position - _transformToMove.position) <= _sqrTargetRadius;
    }
}
