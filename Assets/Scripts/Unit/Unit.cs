namespace Unit
{
    using System;
    using System.Collections.Generic;
    using Common.Spawn;
    using Pickable;
    using UnityEngine;

    public class Unit : PooledComponent
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Picker _picker;

        private bool _isBusy;

        public event Action<Unit> BusyStatusChanged;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            private set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    BusyStatusChanged?.Invoke(this);
                }
            }
        }

        private void OnEnable()
        {
            _picker.Picked += MoveToNextTarget;
            _mover.TargetReached += ChooseAction;
        }

        private void OnDisable()
        {
            _picker.Picked -= MoveToNextTarget;
            _mover.TargetReached -= ChooseAction;
        }

        public void SetWay(IList<Transform> targets)
        {
            if (IsBusy == false)
            {
                _mover.SetWay(targets);
                IsBusy = true;
                _rotator.SetTarget(_mover.Target);
            }
        }

        private void ChooseAction()
        {
            if (_mover.Target.TryGetComponent(out IPickable pickable))
            {
                _picker.PickUp(pickable);
            }
            else
            {
                DropItem();
            }
        }

        private void MoveToNextTarget()
        {
            _mover.MoveToNextTarget();
            _rotator.SetTarget(_mover.Target);
        }

        private void DropItem()
        {
            _rotator.SetTarget(null);
            _picker.Drop();
            IsBusy = false;
        }
    }
}