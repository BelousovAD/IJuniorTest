namespace UI.Window
{
    public interface IWindowOpener
    {
        public void Open(string windowId, bool needCloseCurrent);
    }
}