using UnityEngine;
using UnityEngine.Pool;

public class DropletSpawner : MonoBehaviour
{
    [SerializeField] private Droplet _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private SpawnPlane _spawnPlane;
    [SerializeField, Min(1)] private int _poolSize = 1;

    private ObjectPool<Droplet> _dropletPool;

    private void Awake() =>
        _dropletPool = new(
            createFunc: CreateDroplet,
            actionOnDestroy: DestroyDroplet,
            defaultCapacity: _poolSize);

    private Droplet CreateDroplet()
    {
        Droplet droplet = Instantiate(_prefab);
        droplet.Initialize(this);

        return droplet;
    }

    private void DestroyDroplet(Droplet droplet) =>
        Destroy(droplet.gameObject);

    public void Spawn()
    {
        Droplet droplet = _dropletPool.Get();
        droplet.transform.position = _spawnPlane.GetRandomPoint();
        droplet.transform.SetParent(_parent);
        droplet.gameObject.SetActive(true);
    }

    public void Release(Droplet droplet)
    {
        droplet.gameObject.SetActive(false);
        _dropletPool.Release(droplet);
    }
}
