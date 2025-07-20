namespace Common.FSM
{
	using System;
	using System.Collections.Generic;
	using Behaviour;
	using States;

	public class StateMachine : IStateSwitcher, IFixedUpdatable, ILateUpdatable, IUpdatable, IDisposable
	{
		private readonly List<AbstractState> _states;

		private AbstractState _currentState;

		public StateMachine(IEnumerable<AbstractState> states) =>
			_states = new List<AbstractState>(states);

		public void Update(float deltaTime)
		{
			if (_currentState is IUpdatable updatableState)
			{
				updatableState.Update(deltaTime);
			}
		}

		public void FixedUpdate(float deltaTime)
		{
			if (_currentState is IFixedUpdatable fixedUpdatableState)
			{
				fixedUpdatableState.FixedUpdate(deltaTime);
			}
		}

		public void LateUpdate(float deltaTime)
		{
			if (_currentState is ILateUpdatable lateUpdatableState)
			{
				lateUpdatableState.LateUpdate(deltaTime);
			}
		}

		public void SwitchStateTo(AbstractState nextState)
		{
			if (_states.Contains(nextState) == false)
			{
				throw new ArgumentOutOfRangeException(
					nextState.GetType().Name,
					$"State {nextState.GetType().Name} doesnt exist in StateMachine");
			}

			if (nextState == _currentState)
			{
				return;
			}

			_currentState?.Exit();
			_currentState = nextState;
			_currentState?.Enter();
		}

		public void Dispose()
		{
			_currentState?.Exit();
			_states.ForEach(state => state.Dispose());
		}
	}
}