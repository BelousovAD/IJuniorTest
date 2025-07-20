namespace UI.Window
{
    using System;
    using UnityEngine;

    public class Window : AbstractWindowOpener, ICloseable
    {
        [SerializeField] private WindowId _id;

        private bool _isVisible;

        public event Action CloseRequested;
        public event Action<WindowId, bool> OpenRequested;
        public event Action VisibleChanged;

        public WindowId Id => _id;

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

        public override void Open(WindowId windowId, bool needCloseCurrent) =>
            OpenRequested?.Invoke(windowId, needCloseCurrent);

        public void Close() =>
            CloseRequested?.Invoke();

        public void Hide() =>
            IsVisible = false;

        public void Show() =>
            IsVisible = true;
    }
}