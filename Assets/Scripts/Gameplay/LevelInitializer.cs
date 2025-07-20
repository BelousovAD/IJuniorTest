namespace Gameplay
{
    using Character.Enemy;
    using Character.Player;
    using UnityEngine;

    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Start() =>
            InitializeEnemySpawner();

        private void InitializeEnemySpawner() =>
            _enemySpawner.Initialize(_player.transform.position);
    }
}