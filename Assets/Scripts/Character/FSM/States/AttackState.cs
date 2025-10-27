namespace Character.FSM.States
{
    using Common.Behaviour;

    public class AttackState : AbstractCharacterAnimatorState, IUpdatable
    {
        private const float BusyTime = 1f;
        
        private float _busynessCountdown;
        
        public AttackState(CharacterAnimator characterAnimator)
            : base(characterAnimator)
        { }

        public override void Enter()
        {
            IsBusy = true;
            CharacterAnimator.Play(CharacterAnimator.AnimationKey.Shoot);
            _busynessCountdown = BusyTime;
            base.Enter();
        }

        public void Update(float deltaTime)
        {
            _busynessCountdown -= deltaTime;

            if (_busynessCountdown <= 0f)
            {
                _busynessCountdown = 0f;
                IsBusy = false;
            }
        }
    }
}