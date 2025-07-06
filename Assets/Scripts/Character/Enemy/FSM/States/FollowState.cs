using Character.Enemy.ChangeableValue;
using Common.FSM.States;

namespace Character.Enemy.FSM.States
{
    public class FollowState : AbstractState
    {
        private readonly Mover _mover;
        private readonly PlayerTrigger _playerTrigger;

        public FollowState(Mover mover, PlayerTrigger playerTrigger)
        {
            _mover = mover;
            _playerTrigger = playerTrigger;
        }

        public override void Enter()
        {
            _mover.MoveTo(_playerTrigger.Player.transform);
            base.Enter();
        }
    }
}
