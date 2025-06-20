namespace Common
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class AbstractStateMachine<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private List<AbstractState<T>> _states;

        public event Action StateChanged;

        public AbstractState<T> CurrentState { get; private set; }

        public virtual void SwitchStateTo(T nextState)
        {
            if (CurrentState == null)
            {
                SetState(nextState);
            }
            else if (CurrentState.CanSwitchToState(nextState))
            {
                CurrentState.Exit();
                SetState(nextState);
            }
        }

        private void SetState(T nextState)
        {
            CurrentState = _states.Find(state => state.StateType.Equals(nextState));
            CurrentState.Enter();
            StateChanged?.Invoke();
            CurrentState.Process();
        }

#if UNITY_EDITOR
        protected virtual void RefreshStatesArray()
        {
            int statesCount = transform.childCount;
            _states.Clear();

            for (int i = 0; i < statesCount; i++)
            {
                _states.Add(transform.GetChild(i).GetComponent<AbstractState<T>>());
            }
        }
#endif
    }
}
