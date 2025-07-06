namespace Character.Player.FSM.States
{
    public class FallState : AbstractPlayerAnimatorState
    {
        public FallState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            PlayerAnimator.Play(PlayerAnimator.AnimationKey.Fall);
            base.Enter();
        }
    }
}