using System.Collections;
using UnityEngine;

public class SpawnCaller : MonoBehaviour
{
    [SerializeField, Min(0.005f)] private float _spawnDelay = 0.1f;
    [SerializeField, Min(1)] private int _spawnCount = 1;
    [SerializeField] private DropletSpawner _spawner;

    private void OnEnable() =>
        StartCoroutine(SpawnWithDelayRoutine(_spawnDelay));

    private IEnumerator SpawnWithDelayRoutine(float triggerTime)
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(triggerTime);

            for (int i = 0; i < _spawnCount; i++)
            {
                _spawner.Spawn();
            }
        }
    }
}
