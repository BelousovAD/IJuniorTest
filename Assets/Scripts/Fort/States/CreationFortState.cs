namespace Fort.States
{
    using System;
    using Common.FiniteStateMachine.States;
    using Currency;

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
            _gold.ValueChanged += InvokeFortBuilding;
            _root.FreeUnits.Changed += InvokeFortBuilding;
            base.Enter();
        }

        public override void Exit()
        {
            _gold.ValueChanged -= InvokeFortBuilding;
            _root.FreeUnits.Changed -= InvokeFortBuilding;
            base.Exit();
        }

        private void InvokeFortBuilding()
        {
            if (_createCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_createCost), "Can not be negative");
            }

            if (_root.FreeUnits.Count > 0 && _gold.TrySpend(_createCost))
            {
                _root.BuildFort();
            }
        }
    }
}