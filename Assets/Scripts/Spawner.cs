using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PooledObject _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private SpawnPlane _spawnPlane;
    [SerializeField, Min(1)] private int _poolSize = 1;

    private ObjectPool<PooledObject> _objectPool;

    private void Awake() =>
        _objectPool = new(
            createFunc: CreatePooledObject,
            actionOnDestroy: DestroyPooledObject,
            defaultCapacity: _poolSize);

    public void Spawn()
    {
        PooledObject pooledObject = _objectPool.Get();
        pooledObject.transform.position = _spawnPlane.GetRandomPoint();
        pooledObject.transform.SetParent(_parent);
        pooledObject.gameObject.SetActive(true);
    }

    public void Release(PooledObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _objectPool.Release(pooledObject);
    }

    private PooledObject CreatePooledObject()
    {
        PooledObject droplet = Instantiate(_prefab);
        droplet.Initialize(this);

        return droplet;
    }

    private void DestroyPooledObject(PooledObject pooledObject) =>
        Destroy(pooledObject.gameObject);
}
