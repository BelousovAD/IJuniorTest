using Character.Player.ChangeableValue;
using UI.View;

namespace Character.Player.View
{
    public class AbilityChargeSliderView : AbstractSliderView<AbilityCharge>
    {
        protected override void UpdateView() =>
            Slider.value = Parameter.Value / AbilityCharge.MaxValue;
    }
}