using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    public class Way : MonoBehaviour
    {
        [SerializeField] private List<Transform> _waypoints;

        private int _index = 0;

        public Transform Current => _waypoints[_index];

        public void Next() =>
            _index = ++_index % _waypoints.Count;

        public void Previous() =>
            _index = (--_index + _waypoints.Count) % _waypoints.Count;

        private void Awake() =>
            transform.SetParent(null);

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        private void RefreshPointsArray()
        {
            int pointCount = transform.childCount;
            _waypoints.Clear();

            for (int i = 0; i < pointCount; i++)
            {
                _waypoints.Add(transform.GetChild(i));
            }
        }
#endif
    }
}