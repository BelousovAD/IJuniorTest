using System;
using UnityEngine;

namespace UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private WindowID _id;

        private bool _isVisible = false;
        private WindowManipulator _windowManipulator;

        public event Action VisibleChanged;

        public WindowID Id => _id;

        public WindowManipulator WindowManipulator => _windowManipulator;

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

        public void Initialize(WindowManipulator windowManipulator) =>
            _windowManipulator = windowManipulator;

        public void Hide() =>
            IsVisible = false;

        public void Show() =>
            IsVisible = true;
    }
}