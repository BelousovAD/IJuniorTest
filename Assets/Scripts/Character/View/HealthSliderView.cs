using Character.ChangeableValue;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace DevPackages.Character.View
{
    [RequireComponent(typeof(Slider))]
    public class HealthSliderView : AbstractSliderView<Health>
    {
        protected override void UpdateView() =>
            Slider.value = (float)Parameter.Value / Parameter.MaxValue;
    }
}
