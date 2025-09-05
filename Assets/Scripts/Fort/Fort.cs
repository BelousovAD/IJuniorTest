namespace Fort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChangeableValue;
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

        public event Action Initialized;

        public HasFreeUnit HasFreeUnit { get; } = new();

        public FortToBuild FortToBuild { get; } = new();

        public IReadOnlyList<Unit> FreeUnits => _freeUnits.ToList();

        public StateMachine StateMachine { get; private set; }

        private void Start()
        {
            foreach (Unit unit in _units)
            {
                _freeUnits.Enqueue(unit);
            }
            
            HasFreeUnit.SetValue(_freeUnits.Count > 0);
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
                _freeUnits.Enqueue(unit);
                HasFreeUnit.SetValue(_freeUnits.Count > 0);
            }

            if (isActiveAndEnabled)
            {
                unit.BusyStatusChanged += ReleaseUnit;
            }
        }

        public void BuildFort()
        {
            Unit buildingUnit = _freeUnits.Dequeue();
            HasFreeUnit.SetValue(_freeUnits.Count > 0);
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

                if (HasFreeUnit.Value)
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
                HasFreeUnit.SetValue(_freeUnits.Count > 0);

                if (_detectedGold.Count > 0)
                {
                    SendUnit(_detectedGold.Dequeue());
                }
            }
        }

        private void SendUnit(Gold gold)
        {
            _freeUnits.Dequeue().SetWay(new List<Transform>
            {
                gold.transform,
                transform
            });
            HasFreeUnit.SetValue(_freeUnits.Count > 0);
        }
    }
}