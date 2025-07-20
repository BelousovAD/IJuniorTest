namespace Character.Player.FSM.States
{
    using Common.FSM.States;

    public abstract class AbstractCharacterAnimatorState : AbstractState
    {
        protected readonly PlayerAnimator PlayerAnimator;

        public AbstractCharacterAnimatorState(PlayerAnimator playerAnimator) =>
            PlayerAnimator = playerAnimator;
    }
}