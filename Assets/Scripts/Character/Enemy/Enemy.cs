using Common.ChangeableValue;
using Common.FSM;
using UnityEngine;

namespace Character.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Way _way;
        [SerializeField] private ChangeableValueContainer _changeableValueContainer;

        private StateMachine _stateMachine;

        public Mover Mover => _mover;

        public Way Way => _way;

        public ChangeableValueContainer ChangeableValueContainer => _changeableValueContainer;

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