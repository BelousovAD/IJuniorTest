namespace UI.Window
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    public class Window : MonoBehaviour, IWindowOpener, ICloseable
    {
        [SerializeField] private string _id;

        private CanvasGroup _canvasGroup;

        public event Action CloseRequested;
        public event Action<string, bool> OpenRequested;

        public string Id => _id;

        public bool IsVisible { get; private set; }

        private void Awake() =>
            _canvasGroup = GetComponent<CanvasGroup>();

        public void Open(string windowId, bool needCloseCurrent) =>
            OpenRequested?.Invoke(windowId, needCloseCurrent);

        public void Close() =>
            CloseRequested?.Invoke();

        public void Hide()
        {
            IsVisible = false;
            gameObject.SetActive(false);
        }

        public void Show()
        {
            IsVisible = true;
            gameObject.SetActive(true);
        }

        public void Lock() =>
            _canvasGroup.interactable = false;

        public void Unlock() =>
            _canvasGroup.interactable = true;
    }
}