using System;

namespace Common.ChangeableValue
{
    public interface IChangeableValue
    {
        public event Action ValueChanged;
    }
}