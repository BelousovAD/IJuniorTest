using Character.ChangeableValue;
using UI.View;

namespace Character.View
{
    public class HealthTextView : AbstractTextView<Health>
    {
        protected override void UpdateView() =>
            TextField.text = string.Format(TextFormat, Parameter.Value, Parameter.MaxValue);
    }
}
