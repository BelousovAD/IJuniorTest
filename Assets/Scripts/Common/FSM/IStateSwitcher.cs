namespace Common.FSM
{
	using States;

	public interface IStateSwitcher
	{
		public void SwitchStateTo(AbstractState nextState);
	}
}