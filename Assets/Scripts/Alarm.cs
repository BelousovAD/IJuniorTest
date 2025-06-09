using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;

    [SerializeField] private string _triggerTag = "Player";
    [SerializeField, Min(0f)] private float _volumeAdjustingSpeed = 0.333f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
        _audioSource.playOnAwake = false;
        _audioSource.loop = true;
        _audioSource.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_triggerTag))
        {
            _audioSource.enabled = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(_triggerTag))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MaxVolume, _volumeAdjustingSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_triggerTag))
        {
            StartCoroutine(DownVolumeSmoothlyRoutine());
        }
    }

    private IEnumerator DownVolumeSmoothlyRoutine()
    {
        while (_audioSource.volume > 0f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MinVolume, _volumeAdjustingSpeed * Time.deltaTime);

            yield return null;
        }

        _audioSource.Stop();
        _audioSource.enabled = false;
    }
}
