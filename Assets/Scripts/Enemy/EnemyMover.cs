using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _pointRadius = 0.25f;
    [SerializeField] private List<Transform> _waypoints;

    private Transform _target;
    private int _targetIndex = -1;

    private void Awake() =>
        ChooseNextTarget();

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (IsCurrendPointReached())
        {
            ChooseNextTarget();
        }
    }

    private bool IsCurrendPointReached() =>
        Vector2.Distance(_target.position, transform.position) <= _pointRadius;

    private void ChooseNextTarget()
    {
        _targetIndex = ++_targetIndex % _waypoints.Count;
        _target = _waypoints[_targetIndex];
    }
}
