using Common.UI;

namespace UI
{
    public class CloseWindowButton : AbstractButton
    {
        private Window _window;
        
        protected override void Awake()
        {
            base.Awake();
            _window = GetComponentInParent<Window>();
        }

        public override void OnClick() =>
            _window.WindowManipulator.CloseCurrentWindow();
    }
}