using Common.Spawn;
using Gameplay;
using UnityEngine;

namespace Character.Enemy
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private EnemySpawnPoints _spawnPoints;

        public void Spawn()
        {
            if (_spawnPoints.AvailablePointCount > 0)
            {
                SpawnAt(_spawnPoints.GetRandomAvailablePoint());
            }
        }
    }
}