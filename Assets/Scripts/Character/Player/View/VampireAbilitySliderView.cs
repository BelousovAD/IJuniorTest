using Character.Player.ChangeableValue;
using UI.View;

namespace Character.Player.View
{
    public class VampireAbilitySliderView : AbstractSliderView<VampireAbility>
    {
        protected override void UpdateView() =>
            Slider.value = Parameter.Value / VampireAbility.MaxValue;
    }
}