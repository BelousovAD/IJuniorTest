namespace Fort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChangeableValue;
    using Common.ChangeableValue;
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

        private readonly ChangeableQueue<Gold> _detectedGold = new();

        public event Action Initialized;

        public FortToBuild FortToBuild { get; } = new();

        public ChangeableQueue<Unit> FreeUnits { get; } = new();

        public StateMachine StateMachine { get; private set; }

        private void Start()
        {
            foreach (Unit unit in _units)
            {
                FreeUnits.Enqueue(unit);
            }
        }

        private void OnEnable()
        {
            _goldDetector.Detected += AddToQueue;
            _units.ForEach(unit => unit.BusyStatusChanged += ReleaseUnit);
            _detectedGold.Changed += SendUnit;
            FreeUnits.Changed += SendUnit;
            SendUnit();
        }

        private void OnDisable()
        {
            _goldDetector.Detected -= AddToQueue;
            _units.ForEach(unit => unit.BusyStatusChanged -= ReleaseUnit);
            _detectedGold.Changed -= SendUnit;
            FreeUnits.Changed -= SendUnit;
        }

        private void Update() =>
            StateMachine?.Update(Time.deltaTime);
        
        private void LateUpdate() =>
            StateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            StateMachine?.FixedUpdate(Time.fixedTime);

        public void Initialize(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Initialized?.Invoke();
        }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);

            if (unit.IsBusy == false)
            {
                FreeUnits.Enqueue(unit);
            }

            if (isActiveAndEnabled)
            {
                unit.BusyStatusChanged += ReleaseUnit;
            }
        }

        public void BuildFort()
        {
            Unit buildingUnit = FreeUnits.Dequeue();
            _units.Remove(buildingUnit);
            buildingUnit.SetWay(new List<Transform>
            {
                FortToBuild.Value.transform
            });
            FortToBuild.Value.AddUnit(buildingUnit);
            FortToBuild.SetValue(null);
        }

        private void AddToQueue(Gold gold)
        {
            if (_detectedGold.Contains(gold) == false)
            {
                _detectedGold.Enqueue(gold);
            }
        }

        private void ReleaseUnit(Unit unit)
        {
            if (unit.IsBusy == false)
            {
                FreeUnits.Enqueue(unit);
            }
        }

        private void SendUnit()
        {
            if (FreeUnits.Count > 0 && _detectedGold.TryDequeue(out Gold gold))
            {
                FreeUnits.Dequeue().SetWay(new List<Transform>
                {
                    gold.transform,
                    transform
                });
            }
        }
    }
}