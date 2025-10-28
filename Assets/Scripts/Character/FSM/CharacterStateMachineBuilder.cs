namespace Character.FSM
{
    using System;
    using System.Collections.Generic;
    using Common.FSM;
    using Common.FSM.States;
    using Common.FSM.Transitions;
    using Input;
    using Input.ChangeableValue;
    using States;
    using UnityEngine;

    public class CharacterStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly CharacterAnimator _characterAnimator;
        private readonly IInputReader _inputReader;
        private readonly Rigidbody _rigidbody;

        public CharacterStateMachineBuilder(
            CharacterAnimator characterAnimator,
            IInputReader inputReader,
            Rigidbody rigidbody)
        {
            _characterAnimator = characterAnimator;
            _inputReader = inputReader;
            _rigidbody = rigidbody;
        }

        public override StateMachine Build()
        {
            StateMachine stateMachine = base.Build();
            stateMachine.SwitchStateTo(States[typeof(IdleState)]);

            return stateMachine;
        }

        protected override void BuildStates()
        {
            States = new Dictionary<Type, AbstractState>
            {
                [typeof(IdleState)] = new IdleState(_characterAnimator),
                [typeof(RunState)] = new RunState(_characterAnimator),
                [typeof(AttackState)] = new AttackState(_characterAnimator, _rigidbody),
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(IdleState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.MoveInput,
                    () => _inputReader.MoveInput.Value != MoveInput.NeutralValue,
                    States[typeof(RunState)]),
                new Transition(
                    _inputReader.AttackInput,
                    () => _inputReader.AttackInput.Value,
                    States[typeof(AttackState)]),
            });
            States[typeof(RunState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.AttackInput,
                    () => _inputReader.AttackInput.Value,
                    States[typeof(AttackState)]),
                new Transition(
                    _inputReader.MoveInput,
                    () => _inputReader.MoveInput.Value == MoveInput.NeutralValue,
                    States[typeof(IdleState)]),
            });
            States[typeof(AttackState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.MoveInput,
                    () => _inputReader.MoveInput.Value != MoveInput.NeutralValue,
                    States[typeof(RunState)]),
                new Transition(
                    _inputReader.AttackInput,
                    () => _inputReader.AttackInput.Value == false,
                    States[typeof(IdleState)])
            });
        }
    }
}