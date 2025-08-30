namespace Unit
{
    using System;
    using System.Collections;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _target;
        private Coroutine _moving;
        private bool _isTargetReached;

        public event Action TargetReached;

        private void OnEnable()
        {
            if (_target is not null && _moving is null)
            {
                _moving = StartCoroutine(Moving());
            }
        }
        
        private void OnDisable()
        {
            if (_moving is not null)
            {
                StopCoroutine(_moving);
                _moving = null;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform == _target)
            {
                _isTargetReached = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == _target)
            {
                _isTargetReached = true;
            }
        }

        public void MoveTo(Transform target)
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }

            _target = target;
            _isTargetReached = false;
            _moving = StartCoroutine(Moving());
        }
        
        private IEnumerator Moving()
        {
            while (_isTargetReached == false)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _target.transform.position,
                    _speed * Time.deltaTime);

                yield return null;
            }

            _target = null;
            TargetReached?.Invoke();
        }
    }
}