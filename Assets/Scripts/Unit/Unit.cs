namespace Unit
{
    using System;
    using System.Collections.Generic;
    using Pickable;
    using UnityEngine;

    public class Unit : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Picker _picker;

        private Transform _home;
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

        public void Initialize(Transform home) =>
            _home = home;

        public void SetWay(IList<Transform> targets)
        {
            if (IsBusy == false)
            {
                targets.Add(_home);
                _mover.SetWay(targets);
                IsBusy = true;
                _rotator.SetTarget(_mover.Target);
            }
        }

        private void ChooseAction()
        {
            if (_mover.Target == _home)
            {
                DropItem();
            }
            else
            {
                PickUpItem();
            }
        }

        private void MoveToNextTarget()
        {
            _mover.MoveToNextTarget();
            _rotator.SetTarget(_mover.Target);
        }

        private void PickUpItem()
        {
            if (_mover.Target.TryGetComponent(out IPickable pickable))
            {
                _picker.PickUp(pickable);
            }
        }

        private void DropItem()
        {
            _picker.Drop();
            IsBusy = false;
        }
    }
}