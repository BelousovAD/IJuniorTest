using System;
using System.Collections.Generic;
using Character.Player.ChangeableValue;
using Character.Player.FSM.States;
using Common.FSM;
using Common.FSM.States;
using Common.FSM.Transitions;
using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player.FSM
{
    public class PlayerAnimatorStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly IsOnGround _isOnGround;
        private readonly StandaloneInputReader _inputReader;
        private readonly PlayerAnimator _playerAnimator;
        private readonly VerticalVelocity _verticalVelocity;

        public PlayerAnimatorStateMachineBuilder(IsOnGround isOnGround, StandaloneInputReader inputReader,
            PlayerAnimator playerAnimator, VerticalVelocity verticalVelocity)
        {
            _isOnGround = isOnGround;
            _inputReader = inputReader;
            _playerAnimator = playerAnimator;
            _verticalVelocity = verticalVelocity;
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
                [typeof(IdleState)] = new IdleState(_playerAnimator),
                [typeof(FallState)] = new FallState(_playerAnimator),
                [typeof(JumpState)] = new JumpState(_playerAnimator),
                [typeof(MoveState)] = new MoveState(_playerAnimator)
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(IdleState)].AddTransitionRange(new []
            {
                new Transition(
                    _isOnGround,
                    () => _isOnGround.Value == false,
                    States[typeof(FallState)]),
                new Transition(
                    _verticalVelocity,
                    () => _verticalVelocity.Value > VerticalVelocity.NeutralValue,
                    States[typeof(JumpState)]),
                new Transition(
                    _inputReader.HorizontalInput,
                    () => _inputReader.HorizontalInput.Value != HorizontalInput.NeutralValue,
                    States[typeof(MoveState)])
            });
            States[typeof(FallState)].AddTransition(
                new Transition(
                    _isOnGround,
                    () => _isOnGround.Value,
                    States[typeof(IdleState)])
            );
            States[typeof(JumpState)].AddTransitionRange(new []
            {
                new Transition(
                    _verticalVelocity,
                    () => Mathf.Approximately(_verticalVelocity.Value, VerticalVelocity.NeutralValue),
                    States[typeof(IdleState)]),
                new Transition(
                    _verticalVelocity,
                    () => _verticalVelocity.Value < VerticalVelocity.NeutralValue,
                    States[typeof(FallState)])
            });
            States[typeof(MoveState)].AddTransitionRange(new []
            {
                new Transition(
                    _inputReader.HorizontalInput,
                    () => _inputReader.HorizontalInput.Value == HorizontalInput.NeutralValue,
                    States[typeof(IdleState)]),
                new Transition(
                    _isOnGround,
                    () => _isOnGround.Value == false,
                    States[typeof(FallState)]),
                new Transition(
                    _verticalVelocity,
                    () => _verticalVelocity.Value > VerticalVelocity.NeutralValue,
                    States[typeof(JumpState)])
            });
        }
    }
}