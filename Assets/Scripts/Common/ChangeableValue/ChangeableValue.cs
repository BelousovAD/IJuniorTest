using System;

namespace Common.ChangeableValue
{
    public class ChangeableValue<T> : IChangeableValue
    {
        private T _value;
        
        public event Action ValueChanged;

        public T Value
        {
            get
            {
                return _value;
            }

            set
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