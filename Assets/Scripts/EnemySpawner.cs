using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Material _enemyMaterial;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetToFollow;
    [SerializeField] private float _moveSpeed = 1f;

    public void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, _parent);
        enemy.Initialize(_enemyMaterial, _targetToFollow, _moveSpeed);
    }
}
