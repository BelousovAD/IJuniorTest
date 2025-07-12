namespace Character.Player.FSM.States
{
    public class FlyState : AbstractCharacterAnimatorState
    {
        public FlyState(PlayerAnimator playerAnimator)
            : base(playerAnimator)
        { }

        public override void Enter()
        {
            PlayerAnimator.Play(PlayerAnimator.AnimationKey.Fly);
            base.Enter();
        }
    }
}