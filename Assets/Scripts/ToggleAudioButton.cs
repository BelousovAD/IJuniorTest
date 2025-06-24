using UnityEngine;
using UnityEngine.Audio;

public class ToggleAudioButton : AbstractButton
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameter;

    private float _cashedVolume = -80f;
    private float _temporary;

    protected override void ClickHandler()
    {
        _audioMixer.GetFloat(_parameter, out _temporary);
        _audioMixer.SetFloat(_parameter, _cashedVolume);
        _cashedVolume = _temporary;
    }
}
