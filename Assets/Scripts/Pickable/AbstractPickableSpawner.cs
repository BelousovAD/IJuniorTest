namespace Pickable
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class AbstractPickableSpawner<T> : MonoBehaviour where T : MonoBehaviour, IPickable
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private List<Transform> _spawnPoints = new();

        public void SpawnAtPoints()
        {
            foreach (Transform point in _spawnPoints)
            {
                T pickable = Instantiate(_prefab, point.position, Quaternion.identity, _parent);
                pickable.Picked += PickedHandler;
            }
        }

        protected virtual void PickedHandler(IPickable pickable) =>
            pickable.Picked -= PickedHandler;

#if UNITY_EDITOR
        protected virtual void RefreshPointsArray()
        {
            int pointCount = transform.childCount;
            _spawnPoints.Clear();

            for (int i = 0; i < pointCount; i++)
            {
                _spawnPoints.Add(transform.GetChild(i));
            }
        }
#endif
    }
}
