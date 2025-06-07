using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _maxAbsStartRotation = 180f;
    [SerializeField] private List<Transform> _spawnPoints = new();

    public void SpawnAtRandomPoint()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Vector3 rotation = new(0f, Random.Range(-_maxAbsStartRotation, _maxAbsStartRotation), 0f);
        Enemy enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.Euler(rotation), _parent);
        enemy.Initialize();
    }
}
