using UnityEngine;

public class ButtonSound : AbstractButton
{
    [SerializeField] private AudioSource _audioSource;

    protected override void ClickHandler() =>
        _audioSource.Play();
}
