namespace Character.Player.FSM.States
{
    public class MoveState : AbstractCharacterAnimatorState
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