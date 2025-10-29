namespace Gameplay
{
    using Character;
    using Character.FSM;
    using Common.FSM;
    using Input;
    using UnityEngine;
    using Zenject;

    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Character _player;
        [SerializeField] private Rigidbody _playerRigidbody;

        private IInputReader _inputReader;
        private CharacterStateMachineBuilder _characterStateMachineBuilder;
        private StateMachine _stateMachine;

        [Inject]
        private void Initialize(IInputReader inputReader) =>
            _inputReader = inputReader;

        private void Start()
        {
            _characterStateMachineBuilder = new CharacterStateMachineBuilder(
                _player,
                _inputReader,
                _playerRigidbody);
            _stateMachine = _characterStateMachineBuilder.Build();
            _player.Initialize(_stateMachine);
        }
    }
}