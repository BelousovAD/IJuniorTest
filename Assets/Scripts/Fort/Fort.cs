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
    using States;
    using Unit;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class Fort : PooledComponent, IPointerClickHandler
    {
        [SerializeField] private GoldDetector _goldDetector;
        [SerializeField] private List<Unit> _units = new();

        public event Action Initialized;
        public static event Action<Fort> Selected;
        
        public ChangeableQueue<Gold> DetectedGold { get; } = new();

        public FortToBuild FortToBuild { get; } = new();

        public ChangeableQueue<Unit> FreeUnits { get; } = new();

        public StateMachine StateMachine { get; private set; }

        public ChangeableList<Unit> Units { get; } = new();

        private void Awake()
        {
            foreach (Unit unit in _units)
            {
                Units.Add(unit);
                FreeUnits.Enqueue(unit);
            }
        }

        private void OnEnable()
        {
            _goldDetector.Detected += AddGold;

            foreach (Unit unit in Units)
            {
                unit.BusyStatusChanged += ReleaseUnit;
            }
        }

        private void OnDisable()
        {
            _goldDetector.Detected -= AddGold;

            foreach (Unit unit in Units)
            {
                unit.BusyStatusChanged -= ReleaseUnit;
            }
        }

        private void Update() =>
            StateMachine?.Update(Time.deltaTime);
        
        private void LateUpdate() =>
            StateMachine?.LateUpdate(Time.deltaTime);

        private void FixedUpdate() =>
            StateMachine?.FixedUpdate(Time.fixedTime);
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (StateMachine.CurrentState is not BuildingState)
            {
                Selected?.Invoke(this);
            }
        }

        public void Initialize(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Initialized?.Invoke();
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);

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
            Units.Remove(unit);
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