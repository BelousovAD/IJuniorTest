namespace Character.FSM.States
{
    using Common.FSM.States;

    public abstract class AbstractCharacterAnimatorState : AbstractState
    {
        protected readonly CharacterAnimator CharacterAnimator;

        public AbstractCharacterAnimatorState(CharacterAnimator characterAnimator) =>
            CharacterAnimator = characterAnimator;
    }
}