namespace Character.Enemy
{
    using Common.FSM;
    using FSM;
    using Input;
    using UnityEngine;

    public class Enemy : Character
    {
        [SerializeField] private EnemyInputReader _inputReader;
        [SerializeField] private Mover _mover;
        [SerializeField] private PlayerPositionObserver _playerPositionObserver;
        [SerializeField] private Rigidbody _rigidbody;

        public void Initialize(Transform player)
        {
            CharacterStateMachineBuilder stateMachineBuilder = new(this, _inputReader, _rigidbody, null);
            StateMachine stateMachine = stateMachineBuilder.Build();
            Initialize(stateMachine);
            _playerPositionObserver.Initialize(player);
            _mover.Initialize(_inputReader);
        }
    }
}