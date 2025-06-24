using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerVolumeSlider : AbstractSlider
{
    private const float MinValue = 0.0625f;
    private const float MaxValue = 1f;
    private const float LogarithmBase = 2;
    private const float Multiplier = 20;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameter;

    protected override void Awake()
    {
        base.Awake();
        Slider.minValue = MinValue;
        Slider.maxValue = MaxValue;
        Slider.value = MaxValue;
    }

    protected override void ValueChangeHandler(float value) =>
        _audioMixer.SetFloat(_parameter, Mathf.Log(value, LogarithmBase) * Multiplier);
}
