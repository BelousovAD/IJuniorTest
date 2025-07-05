namespace Character.Player.FSM.States
{
    public class FallState : AbstractPlayerAnimatorState
    {
        public FallState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            base.Enter();
            PlayerAnimator.PlayFall();
        }
    }
}