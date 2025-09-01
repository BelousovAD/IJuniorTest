namespace Base
{
    using System.Collections.Generic;
    using Gameplay;
    using Item;
    using Unit;
    using UnityEngine;

    public class Base : MonoBehaviour
    {
        [SerializeField] private GoldDetector _goldDetector;
        [SerializeField] private List<Unit> _units = new();

        private readonly Queue<Gold> _detectedGold = new();
        private readonly Queue<Unit> _freeUnits = new();

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

        private void AddToQueue(Gold gold)
        {
            _detectedGold.Enqueue(gold);

            if (_freeUnits.Count > 0)
            {
                SendUnit(_detectedGold.Dequeue());
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