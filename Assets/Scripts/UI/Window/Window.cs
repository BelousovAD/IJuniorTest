namespace UI.Window
{
    using System;
    using UnityEngine;

    public class Window : MonoBehaviour, IWindowOpener, ICloseable
    {
        [SerializeField] private string _id;

        private bool _isVisible;

        public event Action CloseRequested;
        public event Action<string, bool> OpenRequested;
        public event Action VisibleChanged;

        public string Id => _id;

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            private set
            {
                if (value != _isVisible)
                {
                    _isVisible = value;
                    VisibleChanged?.Invoke();
                }
            }
        }

        public void Open(string windowId, bool needCloseCurrent) =>
            OpenRequested?.Invoke(windowId, needCloseCurrent);

        public void Close() =>
            CloseRequested?.Invoke();

        public void Hide() =>
            IsVisible = false;

        public void Show() =>
            IsVisible = true;
    }
}