namespace DevPackages.UI
{
    using Common;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public abstract class AbstractSliderView<T> : AbstractParameterView<T> where T : IChangableParameter
    {
        protected Slider Slider;

        protected virtual void Awake() =>
            Slider = GetComponent<Slider>();
    }
}