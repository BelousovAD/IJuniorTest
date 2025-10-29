namespace Input
{
    using System;
    using Character.Enemy;
    using Common.ChangeableValue;
    using UnityEngine;

    public class EnemyInputReader : MonoBehaviour, IInputReader
    {
        [SerializeField] private PlayerPositionObserver _playerPositionObserver;
        
        public ChangeableValue<bool> AttackInput { get; private set; }
        public ChangeableValue<Vector2> LookInput => throw new NotImplementedException();
        public ChangeableValue<Vector2> MoveInput { get; private set; }
        
        public void LockMove() =>
            _playerPositionObserver.ForgetDirection();

        public void UnlockMove() =>
            _playerPositionObserver.RemindDirection();

        private void Awake()
        {
            AttackInput = _playerPositionObserver.IsCloseEnough;
            MoveInput = _playerPositionObserver.Direction2D;
        }
    }
}