namespace Character.Player.FSM.States
{
    public class MoveState : AbstractPlayerAnimatorState
    {
        public MoveState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            PlayerAnimator.Play(PlayerAnimator.AnimationKey.Move);
            base.Enter();
        }
    }
}