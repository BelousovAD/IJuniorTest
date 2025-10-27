namespace Character.FSM.States
{
    public class RunState : AbstractCharacterAnimatorState
    {
        public RunState(CharacterAnimator characterAnimator)
            : base(characterAnimator)
        { }

        public override void Enter()
        {
            CharacterAnimator.Play(CharacterAnimator.AnimationKey.Run);
            base.Enter();
        }
    }
}