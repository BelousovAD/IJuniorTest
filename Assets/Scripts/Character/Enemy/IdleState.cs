namespace Character.Enemy
{
    using Common;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class IdleState : AbstractState<EnemyStateType>
    {
        [SerializeField] private Mover _mover;

        public override EnemyStateType StateType =>
            EnemyStateType.Idle;

        public override bool CanSwitchToState(EnemyStateType nextState) =>
            nextState == EnemyStateType.Patrolling || nextState == EnemyStateType.Following;

        public override void Process() =>
            _mover.MoveTo(null);
    }
}
