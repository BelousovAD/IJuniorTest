using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PooledObject _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField, Min(1)] private int _poolSize = 1;

    private ObjectPool<PooledObject> _objectPool;

    private void Awake() =>
        _objectPool = new(
            createFunc: CreatePooledObject,
            actionOnDestroy: DestroyPooledObject,
            defaultCapacity: _poolSize);

    public void SpawnAt(Vector3 position)
    {
        PooledObject pooledObject = _objectPool.Get();
        pooledObject.transform.position = position;
        pooledObject.transform.SetParent(_parent);
        pooledObject.gameObject.SetActive(true);
    }

    public virtual void Release(PooledObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _objectPool.Release(pooledObject);
    }

    private PooledObject CreatePooledObject()
    {
        PooledObject pooledObject = Instantiate(_prefab);
        pooledObject.Initialize(this);

        return pooledObject;
    }

    private void DestroyPooledObject(PooledObject pooledObject) =>
        Destroy(pooledObject.gameObject);
}