namespace Gameplay
{
    using Character.Enemy;
    using Character.Player;
    using Character.Player.ChangeableValue;
    using Character.Player.FSM;
    using Common.FSM;
    using UnityEngine;

    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private IsOnGround _isOnGround;
        [SerializeField] private EnemySpawner _enemySpawner;

        private PlayerAnimatorStateMachineBuilder _playerAnimatorStateMachineBuilder;
        private StateMachine _stateMachine;

        private void Start()
        {
            InitializePlayer();
            InitializeEnemySpawner();
        }

        private void InitializePlayer()
        {
            _playerAnimatorStateMachineBuilder = new PlayerAnimatorStateMachineBuilder(
                _isOnGround,
                _player.PlayerAnimator);
            _stateMachine = _playerAnimatorStateMachineBuilder.Build();
            _player.Initialize(_stateMachine);
        }

        private void InitializeEnemySpawner() =>
            _enemySpawner.Initialize(_player.transform.position);
    }
}