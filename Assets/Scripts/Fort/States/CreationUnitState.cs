namespace Fort.States
{
    using System;
    using System.Collections.Generic;
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
            _root.DetectedGold.Changed += SendUnit;
            _root.FreeUnits.Changed += SendUnit;
            CreateUnit();
            SendUnit();
            base.Enter();
        }

        public override void Exit()
        {
            _gold.ValueChanged -= CreateUnit;
            _root.DetectedGold.Changed -= SendUnit;
            _root.FreeUnits.Changed -= SendUnit;
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
        
        private void SendUnit()
        {
            if (_root.FreeUnits.Count > 0 && _root.DetectedGold.Count > 0)
            {
                Unit unit = _root.FreeUnits.Dequeue();
                Item.Gold gold = _root.DetectedGold.Dequeue();
                unit.SetWay(new List<Transform>
                {
                    gold.transform,
                    _root.transform
                });
            }
        }
    }
}