namespace Enemy
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Patroller : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private List<Transform> _waypoints;

        private int _waypointIndex = -1;

        private void Awake()
        {
            transform.SetParent(null);
            ChooseNextTarget();
        }

        private void OnEnable() =>
            _mover.TargetReached += ChooseNextTarget;

        private void OnDisable() =>
            _mover.TargetReached -= ChooseNextTarget;

        private void ChooseNextTarget()
        {
            _waypointIndex = ++_waypointIndex % _waypoints.Count;
            _mover.SetTarget(_waypoints[_waypointIndex]);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        private void RefreshPointsArray()
        {
            int pointCount = transform.childCount;

            for (int i = 0; i < pointCount; i++)
            {
                _waypoints.Add(transform.GetChild(i));
            }
        }
#endif
    }
}
