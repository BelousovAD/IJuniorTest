namespace Unit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private int _index;
        private Coroutine _moving;
        private bool _isTargetReached;
        private readonly List<Transform> _waypoints = new();

        public event Action TargetReached;

        public Transform Target => _index < 0 || _index >= _waypoints.Count ? null : _waypoints[_index];

        private void OnEnable()
        {
            if (Target is not null && _moving is null)
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
            if (other.transform == Target)
            {
                _isTargetReached = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == Target)
            {
                _isTargetReached = true;
            }
        }
        
        public void SetWay(IEnumerable<Transform> targets)
        {
            _index = -1;
            _waypoints.Clear();
            _waypoints.AddRange(targets);
            MoveToNextTarget();
        }
        
        public void MoveToNextTarget()
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }

            if (_index < _waypoints.Count - 1)
            {
                ++_index;
            }
            else
            {
                return;
            }
            
            _isTargetReached = false;
            _moving = StartCoroutine(Moving());
        }
        
        private IEnumerator Moving()
        {
            while (_isTargetReached == false)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    Target.transform.position,
                    _speed * Time.deltaTime);

                yield return null;
            }

            TargetReached?.Invoke();
        }
    }
}