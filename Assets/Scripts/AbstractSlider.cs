using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class AbstractSlider : MonoBehaviour
{
    protected Slider Slider;

    protected virtual void Awake() =>
        Slider = GetComponent<Slider>();

    protected virtual void OnEnable() =>
        Slider.onValueChanged.AddListener(ValueChangeHandler);

    protected virtual void OnDisable() =>
        Slider.onValueChanged.RemoveListener(ValueChangeHandler);

    protected abstract void ValueChangeHandler(float value);
}
