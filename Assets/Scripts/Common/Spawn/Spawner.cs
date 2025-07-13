using Common.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Common.Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private PooledComponent _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField, Min(1)] private int _poolSize = 1;

        private IObjectPool<PooledComponent> _pool;

        private void Awake() =>
            _pool = new ObjectPool<PooledComponent>(
                createFunc: CreatePooledComponent,
                actionOnDestroy: DestroyPooledComponent,
                defaultCapacity: _poolSize);

        public void SpawnAt(Vector3 position)
        {
            PooledComponent pooledComponent = _pool.Get();
            pooledComponent.transform.position = position;
            pooledComponent.transform.SetParent(_parent);
            pooledComponent.gameObject.SetActive(true);
        }

        public void Release(PooledComponent pooledComponent)
        {
            pooledComponent.gameObject.SetActive(false);
            _pool.Release(pooledComponent);
        }

        private PooledComponent CreatePooledComponent()
        {
            PooledComponent pooledComponent = Instantiate(_prefab);
            pooledComponent.Initialize(_pool);

            return pooledComponent;
        }

        private void DestroyPooledComponent(PooledComponent pooledComponent) =>
            Destroy(pooledComponent.gameObject);
    }
}