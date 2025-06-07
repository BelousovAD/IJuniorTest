using System.Collections;
using UnityEngine;

public class SpawnCaller : MonoBehaviour
{
    [SerializeField, Min(0.005f)] private float _spawnDelay = 2f;
    [SerializeField] private EnemySpawner _spawner;

    private void OnEnable() =>
        StartCoroutine(SpawnWithDelayRoutine(_spawnDelay));

    private IEnumerator SpawnWithDelayRoutine(float triggerTime)
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(triggerTime);
            _spawner.SpawnAtRandomPoint();
        }
    }
}