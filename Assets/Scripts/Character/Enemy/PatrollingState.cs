namespace Character.Enemy
{
    using Common;
    using System.Collections.Generic;
    using UnityEngine;

    public class PatrollingState : AbstractState<EnemyStateType>
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private List<Transform> _waypoints;

        private int _waypointIndex = 0;

        public override EnemyStateType StateType =>
            EnemyStateType.Patrolling;

        private void Awake() =>
            transform.SetParent(null);

        public override bool CanSwitchToState(EnemyStateType nextState) =>
            nextState == EnemyStateType.Following || nextState == EnemyStateType.Idle;

        public override void Enter() =>
            _mover.TargetReached += ChooseNextTarget;

        public override void Exit() =>
            _mover.TargetReached -= ChooseNextTarget;

        public override void Process() =>
            FocusOnCurrentTarget();

        private void ChooseNextTarget()
        {
            _waypointIndex = ++_waypointIndex % _waypoints.Count;
            FocusOnCurrentTarget();
        }

        private void FocusOnCurrentTarget() =>
            _mover.MoveTo(_waypoints[_waypointIndex]);

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        private void RefreshPointsArray()
        {
            int pointCount = transform.childCount;
            _waypoints.Clear();

            for (int i = 0; i < pointCount; i++)
            {
                _waypoints.Add(transform.GetChild(i));
            }
        }
#endif
    }
}
