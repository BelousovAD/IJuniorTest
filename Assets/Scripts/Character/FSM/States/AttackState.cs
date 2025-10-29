namespace Character.FSM.States
{
    using Input;
    using UnityEngine;

    public class AttackState : AbstractCharacterAnimatorState
    {
        private const float BusyTime = 1f;
        
        private readonly IInputReader _inputReader;
        private readonly Rigidbody _rigidbody;
        private float _busynessCountdown;

        public AttackState(CharacterAnimator characterAnimator, IInputReader inputReader, Rigidbody rigidbody)
            : base(characterAnimator)
        {
            _inputReader = inputReader;
            _rigidbody = rigidbody;
        }

        public override void Enter()
        {
            IsBusy = true;
            _inputReader.LockMove();
            _rigidbody.isKinematic = true;
            CharacterAnimator.Play(CharacterAnimator.AnimationKey.Shoot);
            _busynessCountdown = BusyTime;
            base.Enter();
        }

        public override void Exit()
        {
            _rigidbody.isKinematic = false;
            _inputReader.UnlockMove();
            base.Exit();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            _busynessCountdown -= deltaTime;

            if (_busynessCountdown <= 0f)
            {
                _busynessCountdown = 0f;
                IsBusy = false;
            }
        }
    }
}