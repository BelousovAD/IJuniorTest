namespace Character.Player.FSM.States
{
    public class IdleState : AbstractPlayerAnimatorState
    {
        public IdleState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            PlayerAnimator.Play(PlayerAnimator.AnimationKey.Idle);
            base.Enter();
        }
    }
}