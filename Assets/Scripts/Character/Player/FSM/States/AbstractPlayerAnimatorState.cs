using Common.FSM.States;

namespace Character.Player.FSM.States
{
    public abstract class AbstractPlayerAnimatorState : AbstractState
    {
        protected readonly PlayerAnimator PlayerAnimator;

        public AbstractPlayerAnimatorState(PlayerAnimator playerAnimator) =>
            PlayerAnimator = playerAnimator;
    }
}