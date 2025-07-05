using System;

namespace Common.ChangeableValue
{
    public class ChangeableValue<T> : IChangeableValue
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
                _value = value;
                ValueChanged?.Invoke();
            }
        }
    }
}