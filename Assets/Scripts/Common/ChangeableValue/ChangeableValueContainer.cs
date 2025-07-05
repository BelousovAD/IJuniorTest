using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.ChangeableValue
{
    public class ChangeableValueContainer : MonoBehaviour
    {
        private readonly Dictionary<Type, IChangeableValue> _changeableValues = new();
        private bool _isInitialized = false;

        public event Action Initialized;

        public bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }

            private set
            {
                if (_isInitialized == false && value)
                {
                    _isInitialized = value;
                    Initialized?.Invoke();
                }
            }
        }

        private void Awake()
        {
            RefreshContainerValues();
            IsInitialized = true;
        }

        public T Get<T>() where T : IChangeableValue =>
            (T)_changeableValues[typeof(T)];

        private void RefreshContainerValues()
        {
            int childCount = transform.childCount;
            IChangeableValue changeableValue;
            _changeableValues.Clear();

            for (int i = 0; i < childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent(out changeableValue))
                {
                    _changeableValues.Add(changeableValue.GetType(), changeableValue);
                }
            }
        }
    }
}