namespace Common.ChangeableValue
{
    using System;

    public interface IChangeableValue
    {
        public event Action ValueChanged;
    }
}