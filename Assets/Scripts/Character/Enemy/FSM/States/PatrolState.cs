using Common.FSM.States;

namespace Character.Enemy.FSM.States
{
    public class PatrolState : AbstractState
    {
        private readonly Mover _mover;
        private readonly Way _way;

        public PatrolState(Mover mover, Way way)
        {
            _mover = mover;
            _way = way;
        }

        public override void Enter()
        {
            _mover.TargetReached += ChooseNextTarget;
            FocusOnCurrentTarget();
            base.Enter();
        }

        public override void Exit()
        {
            _mover.TargetReached -= ChooseNextTarget;
            base.Exit();
        }

        private void ChooseNextTarget()
        {
            _way.Next();
            FocusOnCurrentTarget();
        }

        private void FocusOnCurrentTarget() =>
            _mover.MoveTo(_way.Current);
    }
}
