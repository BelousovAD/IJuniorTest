using System;
using System.Collections.Generic;
using Character.Enemy.ChangeableValue;
using Character.Enemy.FSM.States;
using Common.FSM;
using Common.FSM.States;
using Common.FSM.Transitions;

namespace Character.Enemy.FSM
{
    public class EnemyStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly Mover _mover;
        private readonly PlayerTrigger _playerTrigger;
        private readonly Way _way;

        public EnemyStateMachineBuilder(Mover mover, PlayerTrigger playerTrigger, Way way)
        {
            _mover = mover;
            _playerTrigger = playerTrigger;
            _way = way;
        }

        public override StateMachine Build()
        {
            StateMachine stateMachine = base.Build();
            stateMachine.SwitchStateTo(States[typeof(PatrolState)]);
            
            return stateMachine;
        }

        protected override void BuildStates()
        {
            States = new Dictionary<Type, AbstractState>
            {
                [typeof(PatrolState)] = new PatrolState(_mover,
                    _way),
                [typeof(FollowState)] = new FollowState(_mover,
                    _playerTrigger)
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(PatrolState)].AddTransition(
                new Transition(_playerTrigger,
                    () => _playerTrigger.Value,
                    States[typeof(FollowState)]));
            States[typeof(FollowState)].AddTransition(
                new Transition(_playerTrigger,
                    () => _playerTrigger.Value == false,
                    States[typeof(PatrolState)]));
        }
    }
}