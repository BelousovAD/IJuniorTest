using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private List<Transform> _spawnPoints = new();

    public void SpawnAtRandomPoint()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Enemy enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.identity, _parent);
        enemy.Initialize();
    }
}
