namespace Fort.States
{
    using System;
    using Common.FiniteStateMachine.States;
    using Common.Spawn;
    using Currency;
    using Unit;
    using UnityEngine;

    public class CreationUnitState : AbstractState
    {
        private readonly Fort _root;
        private readonly Gold _gold;
        private readonly int _spawnCost;
        private readonly Spawner _spawner;
        private readonly Transform _spawnPoint;
        
        public CreationUnitState(Fort rootFort,
            Gold gold,
            int unitSpawnCost,
            Spawner unitSpawner,
            Transform unitSpawnPoint)
        {
            _root = rootFort;
            _gold = gold;
            _spawnCost = unitSpawnCost;
            _spawner = unitSpawner;
            _spawnPoint = unitSpawnPoint;
        }
        
        public override void Enter()
        {
            _gold.ValueChanged += CreateUnit;
            base.Enter();
        }

        public override void Exit()
        {
            _gold.ValueChanged -= CreateUnit;
            base.Exit();
        }

        private void CreateUnit()
        {
            if (_spawnCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_spawnCost), "Can not be negative");
            }

            if (_gold.TrySpend(_spawnCost))
            {
                _root.AddUnit(_spawner.SpawnAt(_spawnPoint.position) as Unit);
            }
        }
    }
}