namespace Character
{
    using Common.FSM;
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        
        private StateMachine _stateMachine;

        public CharacterAnimator Animator => _animator;
        
        private void Update() =>
            _stateMachine?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _stateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _stateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine stateMachine) =>
            _stateMachine = stateMachine;
    }
}