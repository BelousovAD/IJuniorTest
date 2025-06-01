using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private const float ScaleDivider = 2f;

    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField, Min(0)] private int _minSpawnCount = 0;
    [SerializeField, Min(0)] private int _maxSpawnCount = 10;

    public List<Cube> Spawn(Cube clickedCube)
    {
        int spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount + 1);
        List<Cube> spawnedObjects = new();
        Cube spawnedObject;

        for (int i = 0; i < spawnCount; i++)
        {
            spawnedObject = Instantiate(_prefab, clickedCube.transform.position, Quaternion.identity, _parent);
            spawnedObject.transform.localScale = clickedCube.transform.localScale / ScaleDivider;
            spawnedObject.Initialize(clickedCube);
            spawnedObjects.Add(spawnedObject);
        }

        return spawnedObjects;
    }

    private void OnValidate()
    {
        if (_maxSpawnCount <= _minSpawnCount)
        {
            _maxSpawnCount = _minSpawnCount + 1;
        }
    }
}
