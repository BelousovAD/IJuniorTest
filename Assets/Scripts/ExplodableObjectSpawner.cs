using UnityEngine;

public class ExplodableObjectSpawner : MonoBehaviour
{
    private const float ScaleDivider = 2f;

    [SerializeField]
    private ExplodableObject _prefab;
    [SerializeField]
    private Transform _parent;
    [SerializeField, Min(0)]
    private int _minSpawnCount = 0;
    [SerializeField, Min(0)]
    private int _maxSpawnCount = 10;

    private void OnValidate()
    {
        if (_maxSpawnCount <= _minSpawnCount)
        {
            _maxSpawnCount = _minSpawnCount + 1;
        }
    }

    private void OnEnable() =>
        ExplodableObject.Clicked += Spawn;

    private void OnDisable() =>
        ExplodableObject.Clicked -= Spawn;

    private void Spawn(ExplodableObject objectToExplode)
    {
        int spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount + 1);
        ExplodableObject spawnedObject;

        for (int i = 0; i < spawnCount; i++)
        {
            spawnedObject = Instantiate(_prefab, objectToExplode.transform.position, Quaternion.identity, _parent);
            spawnedObject.transform.localScale = objectToExplode.transform.localScale / ScaleDivider;
            spawnedObject.Initialize(objectToExplode);
        }
    }
}
