namespace Common.ChangeableValue
{
    using System;
    using System.Collections.Generic;

    public class ChangeableValue<T> : IChangeableValue
    {
        private T _value;
        private readonly IEqualityComparer<T> _comparer;
        
        public ChangeableValue(IEqualityComparer<T> comparer = null) =>
            _comparer = comparer ?? EqualityComparer<T>.Default;

        public event Action Changed;

        public virtual T Value
        {
            get
            {
                return _value;
            }

            protected set
            {
                if (_comparer.Equals(_value, value) == false)
                {
                    _value = value;
                    Changed?.Invoke();
                }
            }
        }
    }
}