using System;
using System.Collections.Generic;
using Character.Player.ChangeableValue;
using Character.Player.FSM.States;
using Common.FSM;
using Common.FSM.States;
using Common.FSM.Transitions;

namespace Character.Player.FSM
{
    public class PlayerAnimatorStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly IsOnGround _isOnGround;
        private readonly PlayerAnimator _playerAnimator;

        public PlayerAnimatorStateMachineBuilder(IsOnGround isOnGround, PlayerAnimator playerAnimator)
        {
            _isOnGround = isOnGround;
            _playerAnimator = playerAnimator;
        }

        public override StateMachine Build()
        {
            StateMachine stateMachine = base.Build();
            stateMachine.SwitchStateTo(States[typeof(FlyState)]);

            return stateMachine;
        }

        protected override void BuildStates()
        {
            States = new Dictionary<Type, AbstractState>
            {
                [typeof(FlyState)] = new FlyState(_playerAnimator),
                [typeof(MoveState)] = new MoveState(_playerAnimator),
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(FlyState)].AddTransition(
                new Transition(_isOnGround, () => _isOnGround.Value, States[typeof(MoveState)]));
            States[typeof(MoveState)].AddTransition(
                new Transition(_isOnGround, () => _isOnGround.Value == false, States[typeof(FlyState)]));
        }
    }
}