namespace UI
{
    using Common.UI;
    using UnityEngine;
    using Window;

    public class CloseWindowButton : AbstractButton
    {
        [SerializeField] private ICloseable _window;

        public override void OnClick() =>
            _window.Close();
    }
}