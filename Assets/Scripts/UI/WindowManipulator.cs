using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class WindowManipulator : MonoBehaviour
    {
        [SerializeField] private WindowID _startWindowId;
        [SerializeField] private List<Window> _windowPrefabs = new();

        private Stack<Window> _windowsHistory = new();
        private List<Window> _spawnedWindows = new();

        private void Start() =>
            OpenWindow(_startWindowId, false);

        public void OpenWindow(WindowID windowId, bool needCloseCurrent)
        {
            if (_windowsHistory.Count > 0)
            {
                SetWindowStatus(_windowsHistory.Peek(), !needCloseCurrent);
            }

            Window window = _spawnedWindows.Find(window => window.Id == windowId);

            if (window is not null)
            {
                SetWindowStatus(window, true);
            }
            else
            {
                window = SpawnWindow(windowId);

                if (window == null)
                {
                    Debug.LogError($"Can't open window: Window with ID:{windowId} not founded in prefabs list");
                    return;
                }
            }

            window.transform.SetAsLastSibling();
            _windowsHistory.Push(window);
        }

        public void CloseCurrentWindow()
        {
            if (_windowsHistory.Count > 1)
            {
                Window window = _windowsHistory.Pop();
                SetWindowStatus(window, false);
                window = _windowsHistory.Peek();
                SetWindowStatus(window, true);
            }
        }

        private Window SpawnWindow(WindowID windowId)
        {
            Window window = _windowPrefabs.Find(window => window.Id == windowId);

            if (window != null)
            {
                window = Instantiate(window, transform);
                window.Initialize(this);
                _spawnedWindows.Add(window);
                SetWindowStatus(window, true);
            }

            return window;
        }

        private void SetWindowStatus(Window window, bool status)
        {
            if (status)
            {
                window.Show();
            }
            else
            {
                window.Hide();
            }
        }
    }
}