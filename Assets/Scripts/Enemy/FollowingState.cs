namespace Enemy
{
    using Common;
    using UnityEngine;

    public class FollowingState : AbstractState<EnemyStateType>
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private PlayerTrigger _playerTrigger;

        public override EnemyStateType StateType =>
            EnemyStateType.Following;

        public override bool CanSwitchToState(EnemyStateType nextState) =>
            nextState == EnemyStateType.Patrolling || nextState == EnemyStateType.Idle;

        public override void Process() =>
            _mover.MoveTo(_playerTrigger.Player.transform);
    }
}
