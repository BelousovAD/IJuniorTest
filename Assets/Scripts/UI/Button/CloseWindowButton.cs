namespace UI.Button
{
    using UnityEngine;
    using Window;

    public class CloseWindowButton : AbstractButton
    {
        private ICloseable _window;
        
        protected override void Awake()
        {
            base.Awake();
            _window = GetComponentInParent<Window>();

            if (_window is null)
            {
                Debug.LogError($"{nameof(CloseWindowButton)} component requires " +
                               $"{nameof(Window)} component in parent object");
            }
        }

        public override void HandleClick() =>
            _window.Close();
    }
}