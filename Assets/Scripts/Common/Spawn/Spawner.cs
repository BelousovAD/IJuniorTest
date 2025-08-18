using UnityEngine;

namespace Common.Spawn
{
    using System;
    using UnityEngine.Pool;

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private PooledComponent _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField, Min(1)] private int _poolSize = 1;

        private IObjectPool<PooledComponent> _pool;
        
        public event Action<PooledComponent> ComponentReleased;

        private void Awake() =>
            _pool = new ObjectPool<PooledComponent>(
                createFunc: CreatePooledComponent,
                actionOnRelease: ReleasePooledComponent,
                actionOnDestroy: DestroyPooledComponent,
                defaultCapacity: _poolSize);

        public void SpawnAt(Vector3 position)
        {
            PooledComponent pooledComponent = _pool.Get();
            pooledComponent.transform.position = position;
            pooledComponent.ReleaseRequested += _pool.Release;
            pooledComponent.gameObject.SetActive(true);
        }

        private void ReleasePooledComponent(PooledComponent pooledComponent)
        {
            pooledComponent.gameObject.SetActive(false);
            pooledComponent.ReleaseRequested -= _pool.Release;
            ComponentReleased?.Invoke(pooledComponent);
        }

        private PooledComponent CreatePooledComponent()
        {
            PooledComponent pooledComponent = Instantiate(_prefab, _parent);

            return pooledComponent;
        }

        private void DestroyPooledComponent(PooledComponent pooledComponent) =>
            Destroy(pooledComponent.gameObject);
    }
}