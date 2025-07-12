using Character.Player;
using Character.Player.ChangeableValue;
using Character.Player.FSM;
using Common.FSM;
using UnityEngine;

namespace Gameplay
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private IsOnGround _isOnGround;

        private PlayerAnimatorStateMachineBuilder _playerAnimatorStateMachineBuilder;
        private StateMachine _stateMachine;

        private void Start() =>
            InitializePlayer();

        private void InitializePlayer()
        {
            _playerAnimatorStateMachineBuilder = new PlayerAnimatorStateMachineBuilder(
                _isOnGround,
                _player.PlayerAnimator);
            _stateMachine = _playerAnimatorStateMachineBuilder.Build();
            _player.Initialize(_stateMachine);
        }
    }
}