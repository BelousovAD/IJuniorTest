namespace Character.FSM.States
{
    public class IdleState : AbstractCharacterAnimatorState
    {
        public IdleState(CharacterAnimator characterAnimator)
            : base(characterAnimator)
        { }

        public override void Enter()
        {
            CharacterAnimator.Play(CharacterAnimator.AnimationKey.Idle);
            base.Enter();
        }
    }
}