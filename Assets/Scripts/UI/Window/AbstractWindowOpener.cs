namespace UI.Window
{
    using UnityEngine;

    public abstract class AbstractWindowOpener : MonoBehaviour
    {
        public abstract void Open(WindowId windowId, bool needCloseCurrent);
    }
}