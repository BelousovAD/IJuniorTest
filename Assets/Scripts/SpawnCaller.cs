using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCaller : MonoBehaviour
{
    [SerializeField, Min(0.005f)] private float _spawnDelay = 2f;
    [SerializeField] private List<EnemySpawner> _spawners = new();

    private void OnEnable() =>
        StartCoroutine(SpawnWithDelayRoutine(_spawnDelay));

    private IEnumerator SpawnWithDelayRoutine(float triggerTime)
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(triggerTime);
            _spawners[Random.Range(0, _spawners.Count)].Spawn();
        }
    }
}