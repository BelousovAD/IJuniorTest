namespace Character.FSM.States
{
    using Input;
    using UnityEngine;

    public class AttackState : AbstractCharacterAnimatorState
    {
        private const float BusyTime = 1f;

        private readonly Character _character;
        private readonly IInputReader _inputReader;
        private readonly Rigidbody _rigidbody;
        private float _busynessCountdown;

        public AttackState(Character character, IInputReader inputReader, Rigidbody rigidbody)
            : base(character.Animator)
        {
            _character = character;
            _inputReader = inputReader;
            _rigidbody = rigidbody;
        }

        public override void Enter()
        {
            IsBusy = true;
            _inputReader.LockMove();
            _rigidbody.isKinematic = true;

            CharacterAnimator.Play(_character.HasGun
                ? CharacterAnimator.AnimationKey.Shoot
                : CharacterAnimator.AnimationKey.Slash);

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