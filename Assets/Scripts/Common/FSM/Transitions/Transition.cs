namespace Common.FSM.Transitions
{
    using System;
    using ChangeableValue;
    using States;

    public class Transition : IDisposable
    {
        private readonly Func<bool> _condition;
        private readonly IChangeableValue _parameterToCheck;

        public Transition(IChangeableValue parameterToCheck, Func<bool> condition, AbstractState nextState)
        {
            _parameterToCheck = parameterToCheck;
            _condition = condition;
            NextState = nextState;
            _parameterToCheck.ValueChanged += CheckCondition;
        }

        public event Action<Transition> ConditionMet;
        
        public AbstractState NextState { get; }

        public void Dispose() =>
            _parameterToCheck.ValueChanged -= CheckCondition;

        public void CheckCondition()
        {
            if (_condition.Invoke())
            {
                ConditionMet?.Invoke(this);
            }
        }
    }
}