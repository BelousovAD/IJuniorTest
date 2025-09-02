namespace Common.FiniteStateMachine
{
	using States;

	public interface IStateSwitcher
	{
		public void SwitchStateTo(AbstractState nextState);
	}
}