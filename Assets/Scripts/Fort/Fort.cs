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
    using UnityEngine.EventSystems;

    public class Fort : PooledComponent, IPointerClickHandler
    {
        [SerializeField] private GoldDetector _goldDetector;
        [SerializeField] private List<Unit> _units = new();

        public static event Action<Fort> Selected;
        public event Action Initialized;

        public FortToBuild FortToBuild { get; } = new();
        
        public ChangeableQueue<Gold> DetectedGold { get; } = new();

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
            _goldDetector.Detected += AddGold;
            _units.ForEach(unit => unit.BusyStatusChanged += ReleaseUnit);
        }

        private void OnDisable()
        {
            _goldDetector.Detected -= AddGold;
            _units.ForEach(unit => unit.BusyStatusChanged -= ReleaseUnit);
        }

        private void Update() =>
            StateMachine?.Update(Time.deltaTime);
        
        private void LateUpdate() =>
            StateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            StateMachine?.FixedUpdate(Time.fixedTime);
        
        public void OnPointerClick(PointerEventData eventData) =>
            Selected?.Invoke(this);

        public void Initialize(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Initialized?.Invoke();
        }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);

            if (isActiveAndEnabled)
            {
                unit.BusyStatusChanged += ReleaseUnit;
            }

            if (unit.IsBusy == false)
            {
                FreeUnits.Enqueue(unit);
            }
        }

        public void RemoveUnit(Unit unit)
        {
            unit.BusyStatusChanged -= ReleaseUnit;
            _units.Remove(unit);
        }

        private void AddGold(Gold gold)
        {
            if (DetectedGold.Contains(gold) == false)
            {
                DetectedGold.Enqueue(gold);
            }
        }

        private void ReleaseUnit(Unit unit)
        {
            if (unit.IsBusy == false)
            {
                FreeUnits.Enqueue(unit);
            }
        }
    }
}