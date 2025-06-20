namespace Common
{
    using System;
    using UnityEngine;

    public abstract class AbstractState<T> : MonoBehaviour where T : Enum
    {
        public abstract T StateType { get; }

        public abstract bool CanSwitchToState(T nextState);

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Process() { }
    }
}
