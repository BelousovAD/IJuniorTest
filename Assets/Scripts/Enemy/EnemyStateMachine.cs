namespace Enemy
{
    using Common;
    using UnityEngine;

    public class EnemyStateMachine : AbstractStateMachine<EnemyStateType>
    {
        [SerializeField] private PlayerTrigger _playerTrigger;

        private void OnEnable()
        {
            _playerTrigger.Triggered += SwitchCurrentState;
            SwitchStateTo(EnemyStateType.Patrolling);
        }

        private void OnDisable()
        {
            _playerTrigger.Triggered -= SwitchCurrentState;
            SwitchStateTo(EnemyStateType.Idle);
        }

        private void SwitchCurrentState()
        {
            switch (CurrentState.StateType)
            {
                case EnemyStateType.Patrolling:
                    SwitchStateTo(EnemyStateType.Following);
                    break;
                case EnemyStateType.Following:
                    SwitchStateTo(EnemyStateType.Patrolling);
                    break;
            }
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshStatesArray))]
        protected override void RefreshStatesArray() =>
            base.RefreshStatesArray();
#endif
    }
}
