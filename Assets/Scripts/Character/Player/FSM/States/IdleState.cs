namespace Character.Player.FSM.States
{
    public class IdleState : AbstractPlayerAnimatorState
    {
        public IdleState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            base.Enter();
            PlayerAnimator.PlayIdle();
        }
    }
}