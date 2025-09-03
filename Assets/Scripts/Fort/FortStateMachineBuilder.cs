namespace Fort
{
    using System;
    using System.Collections.Generic;
    using Common.FiniteStateMachine;
    using Common.FiniteStateMachine.States;
    using Common.Spawn;
    using Currency;
    using States;
    using Unit;
    using UnityEngine;

    public class FortStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly Action<Unit> _callback;
        private readonly Gold _gold;
        private readonly Spawner _unitSpawner;
        private readonly int _unitSpawnCost;
        private readonly Vector3 _unitSpawnPoint;

        public FortStateMachineBuilder(Gold gold,
            Spawner unitSpawner,
            int unitSpawnCost,
            Vector3 unitSpawnPoint,
            Action<Unit> callback = null)
        {
            _callback = callback;
            _gold = gold;
            _unitSpawner = unitSpawner;
            _unitSpawnCost = unitSpawnCost;
            _unitSpawnPoint = unitSpawnPoint;
        }

        public override StateMachine Build()
        {
            StateMachine stateMachine = base.Build();
            stateMachine.SwitchStateTo(States[typeof(CreationUnitState)]);

            return stateMachine;
        }

        protected override void BuildStates()
        {
            States = new Dictionary<Type, AbstractState>
            {
                [typeof(CreationUnitState)] = new CreationUnitState(_gold,
                    _unitSpawner,
                    _unitSpawnCost,
                    _unitSpawnPoint,
                    _callback)
            };
        }

        protected override void BuildTransitions()
        { }
    }
}