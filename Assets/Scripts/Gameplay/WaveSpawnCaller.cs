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

        private int _waveIndex = -1;
        private int _ordinaryCount;
        private int _bossCount;
        private WaitForSeconds _delay;

        public event Action Completed;
        public event Action WaveIndexChanged;

        public int WaveIndex
        {
            get
            {
                return _waveIndex;
            }

            private set
            {
                if (value != _waveIndex)
                {
                    _waveIndex = value;
                    WaveIndexChanged?.Invoke();
                }
            }
        }

        public int WaveCount => _waves.Count;

        private void Awake() =>
            _delay = new WaitForSeconds(_spawnDelay);

        private void OnEnable()
        {
            _ordinarySpawner.ComponentReleased += CallBossSubwave;
            _bossSpawner.ComponentReleased += CallNextWave;
            CallNextWave(null);
        }

        private void OnDisable()
        {
            _bossSpawner.ComponentReleased -= CallNextWave;
            _ordinarySpawner.ComponentReleased -= CallBossSubwave;
        }

        private void CallBossSubwave(PooledComponent pooledComponent)
        {
            _ordinaryCount--;

            if (_ordinaryCount > 0)
            {
                return;
            }

            _bossCount = _waves[WaveIndex].BossEnemyCount;
            StartCoroutine(SpawnWithDelay(_bossSpawner, _bossCount));
        }

        private void CallNextWave(PooledComponent pooledComponent)
        {
            _bossCount--;

            if (_bossCount > 0)
            {
                return;
            }

            if (WaveIndex < WaveCount - 1)
            {
                WaveIndex++;
                _ordinaryCount = _waves[WaveIndex].OrdinaryEnemyCount;
                StartCoroutine(SpawnWithDelay(_ordinarySpawner, _ordinaryCount));
            }
            else
            {
                Completed?.Invoke();
            }
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