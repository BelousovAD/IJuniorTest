namespace Common.FSM.States
{
    using System;
    using System.Collections.Generic;
    using Transitions;

    public abstract class AbstractState : IEnterable, IExitable, IDisposable
    {
        private readonly List<Transition> _transitions = new ();
        private IStateSwitcher _stateSwitcher;

        public void AddTransition(Transition transition) =>
            _transitions.Add(transition);

        public void AddTransitionRange(IEnumerable<Transition> transitions) =>
            _transitions.AddRange(transitions);

        public virtual void Enter()
        {
            SubscribeToTransitions();
            CheckTransitions();
        }

        public virtual void Exit() =>
            UnsubscribeFromTransitions();

        public void Dispose()
        {
            _transitions.ForEach(transition =>
            {
                transition.ConditionMet -= SwitchState;
                transition.Dispose();
            });
        }

        public void SetStateSwitcher(IStateSwitcher stateSwitcher) =>
            _stateSwitcher = stateSwitcher;

        private void SubscribeToTransitions() =>
            _transitions.ForEach(transition => transition.ConditionMet += SwitchState);

        private void UnsubscribeFromTransitions() =>
            _transitions.ForEach(transition => transition.ConditionMet -= SwitchState);

        private void CheckTransitions() =>
            _transitions.ForEach(transition => transition.CheckCondition());

        private void SwitchState(Transition transition) =>
            _stateSwitcher.SwitchStateTo(transition.NextState);
    }
}
