namespace DevPackages.Character.UI.View
{
    using Character;
    using DevPackages.UI.View;

    public class HealthTextView : AbstractTextView<Health>
    {
        protected override void UpdateView() =>
            TextField.text = string.Format(TextFormat, Parameter.Value, Parameter.MaxValue);
    }
}
