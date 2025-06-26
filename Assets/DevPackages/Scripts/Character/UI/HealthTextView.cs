namespace DevPackages.Character.UI
{
    using Character;
    using DevPackages.UI;

    public class HealthTextView : AbstractTextView<Health>
    {
        protected override void UpdateView() =>
            TextField.text = string.Format(TextFormat, Parameter.Value, Parameter.MaxValue);
    }
}
