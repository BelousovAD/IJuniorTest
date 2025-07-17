using Common.Spawn;
using UnityEngine;

namespace Character.Enemy
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private EnemySpawnPoints _spawnPoints;

        private Enemy _enemyInstance;
        private Vector3 _spawnPosition;
        private Vector3 _playerPosition;
        private float _distanceToCheckPlayer;

        public void Initialize(Vector3 playerPosition) =>
            _playerPosition = playerPosition;

        public void Spawn()
        {
            if (_spawnPoints.AvailablePointCount > 0)
            {
                _spawnPosition = _spawnPoints.GetRandomAvailablePoint();
                _enemyInstance = (Enemy)SpawnAt(_spawnPosition);
                // NOTE: Игрок находится слева от врага.
                // Вычисляется длина проекции вектора EnemyPosition->PlayerPosition на вектор взгляда врага Left
                _distanceToCheckPlayer = Vector2.Dot(_playerPosition - _spawnPosition, Vector2.left);
                _enemyInstance.Initialize(_distanceToCheckPlayer);
            }
        }
    }
}