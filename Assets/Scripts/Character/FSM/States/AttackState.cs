namespace Character.FSM.States
{
    using Common.Behaviour;
    using UnityEngine;

    public class AttackState : AbstractCharacterAnimatorState, IUpdatable
    {
        private const float BusyTime = 1f;
        
        private readonly Rigidbody _rigidbody;
        private float _busynessCountdown;

        public AttackState(CharacterAnimator characterAnimator, Rigidbody rigidbody)
            : base(characterAnimator) =>
            _rigidbody = rigidbody;

        public override void Enter()
        {
            IsBusy = true;
            _rigidbody.isKinematic = true;
            CharacterAnimator.Play(CharacterAnimator.AnimationKey.Shoot);
            _busynessCountdown = BusyTime;
            base.Enter();
        }

        public override void Exit()
        {
            _rigidbody.isKinematic = false;
            base.Exit();
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