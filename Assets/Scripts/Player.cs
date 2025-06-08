using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private List<Transform> _waypoints = new();
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _pointRadius = 0.25f;

    private Transform _target;
    private int _targetIndex = -1;

    protected override void Awake()
    {
        base.Awake();
        Mover.Speed = _speed;
        ChooseNextTarget();
    }

    private void Update()
    {
        if (IsCurrendPointReached())
        {
            ChooseNextTarget();
        }
    }

    private bool IsCurrendPointReached() =>
        Vector3.Magnitude(_target.position - transform.position) <= _pointRadius;

    private void ChooseNextTarget()
    {
        _targetIndex = ++_targetIndex % _waypoints.Count;
        _target = _waypoints[_targetIndex];
        SetTarget(_target);
    }
}
