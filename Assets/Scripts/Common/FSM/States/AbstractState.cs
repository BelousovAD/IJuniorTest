using System;
using System.Collections.Generic;
using Common.FSM.Transitions;

namespace Common.FSM.States
{
    public abstract class AbstractState : IEnterable, IExitable, IDisposable
    {
        private readonly List<Transition> _transitions = new ();
        private IStateSwitcher _stateSwitcher;
        private bool _isBusy;

        private event Action BusynessChanged;

        protected bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    BusynessChanged?.Invoke();
                }
            }
        }

        public void AddTransition(Transition transition) =>
            _transitions.Add(transition);

        public void AddTransitionRange(IEnumerable<Transition> transitions) =>
            _transitions.AddRange(transitions);

        public virtual void Enter()
        {
            SubscribeToTransitions();
            BusynessChanged += CheckTransitions;
            CheckTransitions();
        }

        public virtual void Exit()
        {
            BusynessChanged -= CheckTransitions;
            UnsubscribeFromTransitions();
        }

        public void Dispose()
        {
            BusynessChanged -= CheckTransitions;
            
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

        private void CheckTransitions()
        {
            if (IsBusy == false)
            {
                _transitions.ForEach(transition => transition.CheckCondition());
            }
        }

        private void SwitchState(Transition transition)
        {
            if (IsBusy == false)
            {
                _stateSwitcher.SwitchStateTo(transition.NextState);
            }
        }
    }
}
