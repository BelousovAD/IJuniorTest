namespace UI.Window
{
    using System.Collections.Generic;
    using UnityEngine;

    public class WindowManipulator : MonoBehaviour
    {
        [SerializeField] private WindowId _startWindowId;
        [SerializeField] private List<Window> _windowPrefabs = new();

        private Stack<Window> _windowsHistory = new();
        private List<Window> _spawnedWindows = new();

        private void Start() =>
            OpenWindow(_startWindowId);

        public void OpenWindow(WindowId windowId, bool needCloseCurrent = false)
        {
            if (_windowsHistory.Count > 0)
            {
                SetWindowStatus(_windowsHistory.Peek(), !needCloseCurrent);
            }

            Window window = _spawnedWindows.Find(window => window.Id == windowId);

            if (window is null)
            {
                window = SpawnWindow(windowId);

                if (window is null)
                {
                    Debug.LogError($"Can't open window: Window with ID:{windowId} not founded in prefabs list");
                    return;
                }
            }

            _windowsHistory.Push(window);
            window.transform.SetAsLastSibling();
            SetWindowStatus(window, true);
        }

        public void CloseCurrentWindow()
        {
            if (_windowsHistory.Count > 0)
            {
                Window window = _windowsHistory.Pop();
                SetWindowStatus(window, false);

                if (_windowsHistory.Count > 0)
                {
                    window = _windowsHistory.Peek();
                    SetWindowStatus(window, true);
                }
            }
        }

        private Window SpawnWindow(WindowId windowId)
        {
            Window window = _windowPrefabs.Find(window => window.Id == windowId);

            if (window is not null)
            {
                window = Instantiate(window, transform);
                _spawnedWindows.Add(window);
            }

            return window;
        }

        private void SetWindowStatus(Window window, bool status)
        {
            if (status)
            {
                window.CloseRequested += CloseCurrentWindow;
                window.OpenRequested += OpenWindow;
                window.Show();
            }
            else
            {
                window.CloseRequested -= CloseCurrentWindow;
                window.OpenRequested -= OpenWindow;
                window.Hide();
            }
        }
    }
}