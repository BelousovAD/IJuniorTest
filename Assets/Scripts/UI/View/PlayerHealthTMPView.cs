namespace UI.View
{
    using Character.ChangeableValue;
    using Zenject;

    public class PlayerHealthTMPView : AbstractTMPView
    {
        private Health _health;

        [Inject]
        private void Initialize(Health health) =>
            _health = health;

        private void OnEnable()
        {
            _health.ValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _health.ValueChanged -= UpdateView;

        public override void UpdateView() =>
            TextField.text = _health is null
                ? string.Empty
                : string.Format(Format, _health.Value, _health.MaxValue);
    }
}