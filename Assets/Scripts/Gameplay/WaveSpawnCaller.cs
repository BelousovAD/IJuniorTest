namespace Gameplay
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Character.Enemy;
    using Common.Spawn;
    using UnityEngine;

    public class WaveSpawnCaller : MonoBehaviour
    {
        [SerializeField, Min(0.005f)] private float _spawnDelay = 0.1f;
        [SerializeField] private EnemySpawner _ordinarySpawner;
        [SerializeField] private EnemySpawner _bossSpawner;
        [SerializeField] private List<Wave> _waves = new();

        private int _currentWaveIndex = -1;
        private int _currentBossCount = 1;
        private WaitForSeconds _delay;

        private void Awake() =>
            _delay = new WaitForSeconds(_spawnDelay);

        private void OnEnable()
        {
            _bossSpawner.ComponentReleased += CallNextWave;
            CallNextWave(null);
        }

        private void OnDisable() =>
            _bossSpawner.ComponentReleased -= CallNextWave;

        private void CallNextWave(PooledComponent pooledComponent)
        {
            _currentBossCount--;

            if (_currentBossCount > 0)
            {
                return;
            }
            
            _currentWaveIndex++;

            if (_currentWaveIndex < _waves.Count)
            {
                StartCoroutine(SpawnWaveWithDelay(
                    _waves[_currentWaveIndex].OrdinaryEnemyCount,
                    _waves[_currentWaveIndex].BossEnemyCount));
            }
        }

        private IEnumerator SpawnWaveWithDelay(int ordinaryCount, int bossCount)
        {
            yield return StartCoroutine(SpawnWithDelay(_ordinarySpawner, ordinaryCount));

            yield return StartCoroutine(SpawnWithDelay(_bossSpawner, bossCount));
        }

        private IEnumerator SpawnWithDelay(EnemySpawner enemySpawner, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (isActiveAndEnabled)
                {
                    yield return _delay;
                    
                    enemySpawner.Spawn();
                }
                else
                {
                    yield break;
                }
            }
        }

        [Serializable]
        private struct Wave
        {
            [Min(0)] public int OrdinaryEnemyCount;
            [Min(0)] public int BossEnemyCount;
        }
    }
}