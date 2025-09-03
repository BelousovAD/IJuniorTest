namespace Fort
{
    using System.Collections.Generic;
    using Common.FiniteStateMachine;
    using Common.Spawn;
    using Gameplay;
    using Item;
    using Unit;
    using UnityEngine;

    public class Fort : PooledComponent
    {
        [SerializeField] private GoldDetector _goldDetector;
        [SerializeField] private List<Unit> _units = new();

        private readonly Queue<Gold> _detectedGold = new();
        private readonly Queue<Unit> _freeUnits = new();
        private StateMachine _stateMachine;

        private void Start()
        {
            foreach (Unit unit in _units)
            {
                unit.Initialize(transform);
                _freeUnits.Enqueue(unit);
            }
        }

        private void OnEnable()
        {
            _goldDetector.Detected += AddToQueue;
            _units.ForEach(unit => unit.BusyStatusChanged += ReleaseUnit);
        }

        private void OnDisable()
        {
            _goldDetector.Detected -= AddToQueue;
            _units.ForEach(unit => unit.BusyStatusChanged -= ReleaseUnit);
        }

        private void Update() =>
            _stateMachine?.Update(Time.deltaTime);
        
        private void LateUpdate() =>
            _stateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            _stateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
            unit.Initialize(transform);
            _freeUnits.Enqueue(unit);

            if (isActiveAndEnabled)
            {
                unit.BusyStatusChanged += ReleaseUnit;
            }
        }

        private void AddToQueue(Gold gold)
        {
            if (_detectedGold.Contains(gold) == false)
            {
                _detectedGold.Enqueue(gold);

                if (_freeUnits.Count > 0)
                {
                    SendUnit(_detectedGold.Dequeue());
                }
            }
        }

        private void ReleaseUnit(Unit unit)
        {
            if (unit.IsBusy == false)
            {
                _freeUnits.Enqueue(unit);

                if (_detectedGold.Count > 0)
                {
                    SendUnit(_detectedGold.Dequeue());
                }
            }
        }

        private void SendUnit(Gold gold) =>
            _freeUnits.Dequeue().SetWay(new List<Transform> {gold.transform});
    }
}