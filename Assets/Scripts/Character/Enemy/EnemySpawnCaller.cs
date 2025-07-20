namespace Character.Enemy
{
    using System.Collections;
    using UnityEngine;

    public class EnemySpawnCaller : MonoBehaviour
    {
        [SerializeField, Min(0.005f)] private float _spawnDelay = 0.1f;
        [SerializeField] private EnemySpawner _spawner;

        private void OnEnable() =>
            StartCoroutine(SpawnWithDelayRoutine(_spawnDelay));

        private IEnumerator SpawnWithDelayRoutine(float triggerTime)
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(triggerTime);

                _spawner.Spawn();
            }
        }
    }
}