using System;
using UnityEngine;

namespace Common.ChangeableValue
{
    public class ChangeableValueComponent<T> : MonoBehaviour, IChangeableValue
    {
        private T _value;
        
        public event Action ValueChanged;

        public virtual T Value
        {
            get
            {
                return _value;
            }

            protected set
            {
                if (_value.Equals(value) == false)
                {
                    _value = value;
                    ValueChanged?.Invoke();
                }
            }
        }
    }
}