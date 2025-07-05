using System.Collections.Generic;
using Character.Enemy;
using Character.Enemy.ChangeableValue;
using Character.Enemy.FSM;
using Character.Player;
using Character.Player.ChangeableValue;
using Character.Player.FSM;
using Common.FSM;
using Input;
using UnityEngine;

namespace Gameplay
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private StandaloneInputReader _inputReader;
        [SerializeField] private List<Enemy> _enemies;

        private EnemyStateMachineBuilder _enemyStateMachineBuilder;
        private PlayerAnimatorStateMachineBuilder _playerAnimatorStateMachineBuilder;
        private StateMachine _stateMachine;

        private void Start()
        {
            InitializePlayer();
            _enemies.ForEach(InitializeEnemy);
        }

        private void InitializeEnemy(Enemy enemy)
        {
            _enemyStateMachineBuilder = new EnemyStateMachineBuilder(
                enemy.Mover,
                enemy.ChangeableValueContainer.Get<PlayerTrigger>(),
                enemy.Way);
            _stateMachine = _enemyStateMachineBuilder.Build();
            enemy.Initialize(_stateMachine);
        }

        private void InitializePlayer()
        {
            _playerAnimatorStateMachineBuilder = new PlayerAnimatorStateMachineBuilder(
                _player.ChangeableValueContainer.Get<IsOnGround>(),
                _inputReader,
                _player.PlayerAnimator,
                _player.ChangeableValueContainer.Get<VerticalVelocity>());
            _stateMachine = _playerAnimatorStateMachineBuilder.Build();
            _player.Initialize(_stateMachine);
        }
    }
}