namespace Character.Enemy
{
    using Common.Spawn;
    using UnityEngine;

    public class EnemySpawner : Spawner
    {
        [SerializeField] private Transform _player;
        [SerializeField] private EnemySpawnPoints _enemySpawnPoints;

        public void Spawn()
        {
            Enemy enemy = SpawnAt(_enemySpawnPoints.GetRandomPoint()) as Enemy;
            enemy!.Initialize(_player);
        }
    }
}