namespace Fort.States
{
    using System;
    using System.Collections.Generic;
    using Common.FiniteStateMachine.States;
    using Currency;
    using Unit;
    using UnityEngine;

    public class CreationFortState : AbstractState
    {
        private readonly Fort _root;
        private readonly Gold _gold;
        private readonly int _createCost;
        
        public CreationFortState(Fort rootFort,
            Gold gold,
            int fortCreateCost)
        {
            _root = rootFort;
            _gold = gold;
            _createCost = fortCreateCost;
        }
        
        public override void Enter()
        {
            _gold.Increased += SendUnit;
            _root.DetectedGold.Increased += SendUnit;
            _root.FreeUnits.Increased += SendUnit;
            SendUnit();
            base.Enter();
        }

        public override void Exit()
        {
            _gold.Increased -= SendUnit;
            _root.DetectedGold.Increased -= SendUnit;
            _root.FreeUnits.Increased -= SendUnit;
            base.Exit();
        }

        private void SendUnit()
        {
            if (_createCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_createCost), "Can not be negative");
            }

            if (_root.FreeUnits.Count > 0)
            {
                if (_gold.TrySpend(_createCost))
                {
                    Unit unit = _root.FreeUnits.Dequeue();
                    _root.RemoveUnit(unit);
                    unit.SetWay(new List<Transform>
                    {
                        _root.FortToBuild.Value.transform
                    });
                    _root.FortToBuild.Value.AddUnit(unit);
                    _root.FortToBuild.SetValue(null);
                }
                else if (_root.DetectedGold.Count > 0)
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
}