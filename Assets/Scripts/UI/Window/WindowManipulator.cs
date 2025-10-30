namespace UI.Window
{
    using System.Collections.Generic;
    using UnityEngine;

    public class WindowManipulator : MonoBehaviour
    {
        [SerializeField] private string _startWindowId;
        [SerializeField] private List<Window> _windowPrefabs = new();

        private readonly Stack<Window> _windowsHistory = new();
        private readonly Dictionary<string, Window> _spawnedWindows = new();

        private void Start() =>
            OpenWindow(_startWindowId);

        public void OpenWindow(string windowId, bool needCloseCurrent = false)
        {
            if (_windowsHistory.Count > 0)
            {
                Window lastWindow = _windowsHistory.Peek();

                if (lastWindow.Id == windowId)
                {
                    return;
                }

                if (needCloseCurrent)
                {
                    SetWindowStatus(lastWindow, false);
                }
                else
                {
                    lastWindow.Lock();
                }
            }

            if (_spawnedWindows.TryGetValue(windowId, out Window window) == false)
            {
                window = SpawnWindow(windowId);

                if (window is null)
                {
                    Debug.LogError($"Can't open window with ID:{windowId}. " +
                                   $"It's not founded in prefabs list");
                    return;
                }
            }

            _windowsHistory.Push(window);
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
                    window.Unlock();
                }
            }
        }

        private Window SpawnWindow(string windowId)
        {
            Window window = _windowPrefabs.Find(window => window.Id == windowId);

            if (window is not null)
            {
                window = Instantiate(window, transform);
                _spawnedWindows.Add(windowId, window);
            }

            return window;
        }

        private void SetWindowStatus(Window window, bool status)
        {
            if (status)
            {
                window.transform.SetAsLastSibling();

                if (window.IsVisible == false)
                {
                    window.CloseRequested += CloseCurrentWindow;
                    window.OpenRequested += OpenWindow;
                    window.Show();
                }
            }
            else
            {
                if (window.IsVisible)
                {
                    window.CloseRequested -= CloseCurrentWindow;
                    window.OpenRequested -= OpenWindow;
                    window.Hide();
                }
            }
        }
    }
}