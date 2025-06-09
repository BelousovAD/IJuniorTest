using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;

    [SerializeField, Min(0f)] private float _volumeAdjustingSpeed = 0.333f;
    [SerializeField] private ThiefTrigger _thiefTrigger;

    private AudioSource _audioSource;
    private int _thiefCount = 0;
    private Coroutine _increaseVolumeRoutine;
    private Coroutine _decreaseVolumeRoutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
        _audioSource.playOnAwake = false;
        _audioSource.loop = true;
    }

    private void OnEnable()
    {
        _thiefTrigger.TriggerEnter += IncreaseThiefCount;
        _thiefTrigger.TriggerExit += DecreaseThiefCount;
    }

    private void OnDisable()
    {
        _thiefTrigger.TriggerEnter -= IncreaseThiefCount;
        _thiefTrigger.TriggerExit -= DecreaseThiefCount;
    }

    private void IncreaseThiefCount()
    {
        if (_increaseVolumeRoutine == null && _thiefCount == 0)
        {
            StartCoroutine(StartPlay());
        }

        ++_thiefCount;
    }

    private void DecreaseThiefCount()
    {
        --_thiefCount;

        if (_decreaseVolumeRoutine == null && _thiefCount == 0)
        {
            StartCoroutine(StopPlay());
        }
    }

    private IEnumerator StartPlay()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        CancelCoroutine(ref _decreaseVolumeRoutine);

        yield return _increaseVolumeRoutine = StartCoroutine(ChangeVolumeSmoothly(MaxVolume));

        _increaseVolumeRoutine = null;
    }

    private IEnumerator StopPlay()
    {
        CancelCoroutine(ref _increaseVolumeRoutine);

        yield return _decreaseVolumeRoutine = StartCoroutine(ChangeVolumeSmoothly(MinVolume));

        _decreaseVolumeRoutine = null;
        _audioSource.Stop();
    }

    private void CancelCoroutine(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator ChangeVolumeSmoothly(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeAdjustingSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
