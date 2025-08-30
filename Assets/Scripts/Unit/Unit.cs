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
        [SerializeField] private Transform _handPoint;

        private Transform _home;
        private int _index;
        private bool _isBusy;
        private readonly List<Transform> _waypoints = new();

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
        
        public IPickable Pickable { get; private set; }

        private void OnEnable()
        {
            _picker.Picking += PickUp;
            _mover.TargetReached += MoveToNextTarget;
        }

        private void OnDisable()
        {
            _picker.Picking -= PickUp;
            _mover.TargetReached -= MoveToNextTarget;
        }

        public void Initialize(Transform home) =>
            _home = home;

        public void SetWay(IEnumerable<Transform> targets)
        {
            if (IsBusy == false)
            {
                _index = -1;
                _waypoints.Clear();
                _waypoints.AddRange(targets);
                _waypoints.Add(_home);
                IsBusy = true;
                MoveToNextTarget();
            }
        }

        public void Drop()
        {
            if (Pickable is MonoBehaviour component)
            {
                component.transform.SetParent(null);
            }
            
            Pickable.Drop();
            Pickable = null;
        }

        private void PickUp(IPickable pickable)
        {
            if (Pickable is not null)
            {
                return;
            }
            
            Pickable = pickable;
            Pickable.PickUp();

            if (pickable is MonoBehaviour component)
            {
                component.transform.SetParent(_handPoint);
                component.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            }
            
            MoveToNextTarget();
        }

        private void MoveToNextTarget()
        {
            ++_index;

            if (_index < _waypoints.Count)
            {
                _mover.MoveTo(_waypoints[_index]);
                _rotator.SetTarget(_waypoints[_index]);
            }
            else
            {
                IsBusy = false;
            }
        }
    }
}