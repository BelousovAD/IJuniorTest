using System;
using Common.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Common.Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] protected Transform Parent;
        
        [SerializeField] private PooledComponent _prefab;
        [SerializeField, Min(1)] private int _poolSize = 1;

        private IObjectPool<PooledComponent> _pool;

        public event Action<PooledComponent> ComponentReleased;

        protected virtual void Awake() =>
            _pool = new ObjectPool<PooledComponent>(
                createFunc: CreatePooledComponent,
                actionOnRelease: ReleasePooledComponent,
                actionOnDestroy: DestroyPooledComponent,
                defaultCapacity: _poolSize);

        protected PooledComponent SpawnAt(Vector3 position)
        {
            PooledComponent pooledComponent = _pool.Get();
            pooledComponent.transform.position = position;
            pooledComponent.gameObject.SetActive(true);

            return pooledComponent;
        }

        private void ReleasePooledComponent(PooledComponent pooledComponent)
        {
            pooledComponent.gameObject.SetActive(false);
            ComponentReleased?.Invoke(pooledComponent);
        }

        private PooledComponent CreatePooledComponent()
        {
            PooledComponent pooledComponent = Instantiate(_prefab, Parent);
            pooledComponent.Initialize(_pool);

            return pooledComponent;
        }

        private void DestroyPooledComponent(PooledComponent pooledComponent) =>
            Destroy(pooledComponent.gameObject);
    }
}