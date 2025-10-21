namespace UI.Button
{
    using UnityEngine;
    using Window;

    public class OpenWindowButton : AbstractButton
    {
        [SerializeField] private string _windowId;
        [SerializeField] private bool _needCloseCurrent;
        
        private IWindowOpener _window;

        protected override void Awake()
        {
            base.Awake();
            _window = GetComponentInParent<Window>();

            if (_window is null)
            {
                Debug.LogError($"{nameof(OpenWindowButton)} component requires " +
                               $"{nameof(Window)} component in parent object");
            }
        }

        public override void HandleClick() =>
            _window.Open(_windowId, _needCloseCurrent);
    }
}