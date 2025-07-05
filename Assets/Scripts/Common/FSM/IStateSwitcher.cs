using Common.FSM.States;

namespace Common.FSM
{
	public interface IStateSwitcher
	{
		public void SwitchStateTo(AbstractState nextState);
	}
}