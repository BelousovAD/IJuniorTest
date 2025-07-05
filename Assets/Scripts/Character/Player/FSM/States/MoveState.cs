namespace Character.Player.FSM.States
{
    public class MoveState : AbstractPlayerAnimatorState
    {
        public MoveState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            base.Enter();
            PlayerAnimator.PlayMove();
        }
    }
}