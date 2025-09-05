namespace Fort
{
    using System;
    using System.Collections.Generic;
    using Common.FiniteStateMachine;
    using Common.FiniteStateMachine.States;
    using Common.FiniteStateMachine.Transitions;
    using Common.Spawn;
    using Currency;
    using States;
    using UnityEngine;

    public class FortStateMachineBuilder : AbstractStateMachineBuilder
    {
        private readonly Fort _root;
        private readonly Gold _gold;
        private readonly int _fortSpawnCost;
        private readonly int _unitSpawnCost;
        private readonly Spawner _unitSpawner;
        private readonly Transform _unitSpawnPoint;

        public FortStateMachineBuilder(Fort rootFort,
            Gold gold,
            int fortSpawnCost,
            int unitSpawnCost,
            Spawner unitSpawner,
            Transform unitSpawnPoint)
        {
            _root = rootFort;
            _gold = gold;
            _fortSpawnCost = fortSpawnCost;
            _unitSpawnCost = unitSpawnCost;
            _unitSpawner = unitSpawner;
            _unitSpawnPoint = unitSpawnPoint;
        }

        public override StateMachine Build()
        {
            StateMachine stateMachine = base.Build();
            stateMachine.SwitchStateTo(States[typeof(BuildingState)]);

            return stateMachine;
        }

        protected override void BuildStates()
        {
            States = new Dictionary<Type, AbstractState>
            {
                [typeof(BuildingState)] = new BuildingState(),
                [typeof(CreationUnitState)] = new CreationUnitState(_root,
                    _gold,
                    _unitSpawnCost,
                    _unitSpawner,
                    _unitSpawnPoint),
                [typeof(CreationFortState)] = new CreationFortState(_root,
                    _gold,
                    _fortSpawnCost)
            };
        }

        protected override void BuildTransitions()
        {
            States[typeof(BuildingState)].AddTransition(new Transition(_root.HasFreeUnit,
                () => _root.HasFreeUnit.Value,
                States[typeof(CreationUnitState)]));
            States[typeof(CreationFortState)].AddTransition(new Transition(_root.FortToBuild,
                () => _root.FortToBuild.Value is null,
                States[typeof(CreationUnitState)]));
            States[typeof(CreationUnitState)].AddTransition(new Transition(_root.FortToBuild,
                () => _root.FortToBuild.Value is not null,
                States[typeof(CreationFortState)]));
        }
    }
}