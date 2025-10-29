namespace Character.FSM
{
    using System;
    using System.Collections.Generic;
    using Common.FSM;
    using Common.FSM.States;
    using Common.FSM.Transitions;
    using Input;
    using States;
    using UnityEngine;

    public class CharacterStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly Character _character;
        private readonly IInputReader _inputReader;
        private readonly Rigidbody _rigidbody;

        public CharacterStateMachineBuilder(
            Character character,
            IInputReader inputReader,
            Rigidbody rigidbody)
        {
            _character = character;
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
                [typeof(IdleState)] = new IdleState(_character.Animator),
                [typeof(RunState)] = new RunState(_character.Animator),
                [typeof(AttackState)] = new AttackState(_character, _inputReader, _rigidbody),
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(IdleState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.MoveInput,
                    () => _inputReader.MoveInput.Value != Vector2.zero,
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
                    () => _inputReader.MoveInput.Value == Vector2.zero,
                    States[typeof(IdleState)]),
            });
            States[typeof(AttackState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.MoveInput,
                    () => _inputReader.MoveInput.Value != Vector2.zero,
                    States[typeof(RunState)]),
                new Transition(
                    _inputReader.AttackInput,
                    () => _inputReader.AttackInput.Value == false,
                    States[typeof(IdleState)])
            });
        }
    }
}