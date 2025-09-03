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
        private readonly Action<Unit> _callback;
        private readonly Gold _gold;
        private readonly Spawner _spawner;
        private readonly int _spawnCost;
        private readonly Vector3 _spawnPoint;
        
        public CreationUnitState(Gold gold,
            Spawner unitSpawner,
            int unitSpawnCost,
            Vector3 unitSpawnPoint,
            Action<Unit> callback = null)
        {
            _callback = callback;
            _gold = gold;
            _spawner = unitSpawner;
            _spawnCost = unitSpawnCost;
            _spawnPoint = unitSpawnPoint;
        }
        
        public override void Enter()
        {
            _gold.ValueChanged += SpawnUnit;
            base.Enter();
        }

        public override void Exit()
        {
            _gold.ValueChanged -= SpawnUnit;
            base.Exit();
        }

        private void SpawnUnit()
        {
            if (_spawnCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_spawnCost), "Can not be negative");
            }

            if (_gold.TrySpend(_spawnCost))
            {
                Unit unit = _spawner.SpawnAt(_spawnPoint) as Unit;
                _callback?.Invoke(unit);
            }
        }
    }
}