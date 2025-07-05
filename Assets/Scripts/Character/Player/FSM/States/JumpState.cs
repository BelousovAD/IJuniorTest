namespace Character.Player.FSM.States
{
    public class JumpState : AbstractPlayerAnimatorState
    {
        public JumpState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            base.Enter();
            PlayerAnimator.PlayJump();
        }
    }
}