namespace DevPackages.Common
{
    using System;

    public interface IChangableParameter
    {
        public event Action ValueChanged;
    }
}