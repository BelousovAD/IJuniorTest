namespace Character.FSM.States
{
    using Input;
    using UnityEngine;
    using Weapon;

    public class AttackState : AbstractCharacterAnimatorState
    {
        private const float BusyTime = 1f;
        private const float DelayBeforeAttack = 0.25f;

        private readonly Character _character;
        private readonly IInputReader _inputReader;
        private readonly Rigidbody _rigidbody;
        private readonly Gun _gun;
        private float _busynessCountdown;
        private float _delayCountdown;

        public AttackState(Character character, IInputReader inputReader, Rigidbody rigidbody, Gun gun)
            : base(character.Animator)
        {
            _character = character;
            _inputReader = inputReader;
            _rigidbody = rigidbody;
            _gun = gun;
        }

        public override void Enter()
        {
            IsBusy = true;
            _inputReader.LockMove();
            _rigidbody.isKinematic = true;

            if (_character.HasGun)
            {
                CharacterAnimator.Play(CharacterAnimator.AnimationKey.Shoot);
                _delayCountdown = DelayBeforeAttack;
            }
            else
            {
                CharacterAnimator.Play(CharacterAnimator.AnimationKey.Slash);
            }

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
            if (_busynessCountdown > 0f)
            {
                _busynessCountdown -= deltaTime;
                
                if (_busynessCountdown <= 0f)
                {
                    IsBusy = false;
                }
            }

            if (_delayCountdown > 0f)
            {
                _delayCountdown -= deltaTime;

                if (_delayCountdown <= 0f)
                {
                    _gun.Shoot();
                }
            }
        }
    }
}