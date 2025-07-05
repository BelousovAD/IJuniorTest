using Common.ChangeableValue;
using Common.View;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    [RequireComponent(typeof(Slider))]
    public abstract class AbstractSliderView<T> : AbstractParameterView<T> where T : IChangeableValue
    {
        protected Slider Slider;

        protected virtual void Awake() =>
            Slider = GetComponent<Slider>();
    }
}