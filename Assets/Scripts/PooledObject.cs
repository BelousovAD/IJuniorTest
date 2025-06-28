using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private Spawner _parentSpawner;

    public virtual void Initialize(Spawner parentSpawner) =>
        _parentSpawner = parentSpawner;

    public virtual void Release() =>
        _parentSpawner.Release(this);
}
