using System.Collections.Generic;
using Common.Pool;
using Common.Spawn;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class EnemySpawnPoints : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private List<RectTransform> _points = new();

        private List<RectTransform> _availablePoints;

        public int AvailablePointCount => _availablePoints.Count;

        private void Awake() =>
            _availablePoints = new List<RectTransform>(_points);

        private void OnEnable() =>
            _spawner.ComponentReleased += ReleasePoint;

        private void OnDisable() =>
            _spawner.ComponentReleased -= ReleasePoint;

        public Vector3 GetRandomAvailablePoint()
        {
            RectTransform point = _availablePoints[Random.Range(0, AvailablePointCount)];
            _availablePoints.Remove(point);

            return point.position;
        }

        private void ReleasePoint(PooledComponent pooledComponent)
        {
            RectTransform point = _points.Find(point => point.position == pooledComponent.transform.position);
            _availablePoints.Add(point);
        }
        
#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        private void RefreshPointsArray()
        {
            _points.Clear();
            int pointCount = transform.childCount;

            for (int i = 0; i < pointCount; i++)
            {
                _points.Add(transform.GetChild(i) as RectTransform);
            }
        }
#endif
    }
}