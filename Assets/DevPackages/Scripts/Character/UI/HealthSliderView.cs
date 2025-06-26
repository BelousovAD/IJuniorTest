namespace DevPackages.Character.UI
{
    using Character;
    using DevPackages.UI;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class HealthSliderView : AbstractSliderView<Health>
    {
        protected override void UpdateView() =>
            Slider.value = (float)Parameter.Value / Parameter.MaxValue;
    }
}
