using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private List<Transform> _spawnPoints = new();

    private void Start() =>
        SpawnAtPoints();

    public void SpawnAtPoints()
    {
        foreach (Transform point in _spawnPoints)
        {
            Instantiate(_prefab, point.position, Quaternion.identity, _parent);
        }
    }
}
