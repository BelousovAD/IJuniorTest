using Common;
using UnityEngine;

namespace Droplet
{
    public class DropletSpawner : Spawner
    {
        [SerializeField] private SpawnPlane _spawnPlane;
        [SerializeField] private Spawner _bombSpawner;
    
        public override void Release(PooledObject pooledObject)
        {
            base.Release(pooledObject);
            _bombSpawner.SpawnAt(pooledObject.transform.position);
        }

        public void Spawn() =>
            SpawnAt(_spawnPlane.GetRandomPoint());
    }
}
