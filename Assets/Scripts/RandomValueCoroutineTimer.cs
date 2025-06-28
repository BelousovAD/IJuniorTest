using System;
using System.Collections;
using UnityEngine;

public class RandomValueCoroutineTimer : MonoBehaviour
{
    [SerializeField] private float _minSeconds = 2;
    [SerializeField] private float _maxSeconds = 5;

    private float _triggerTime;

    public event Action Started;
    public event Action TimeIsUp;

    public float TriggerTime => _triggerTime;

    private void OnValidate()
    {
        if (_maxSeconds <= _minSeconds)
        {
            _maxSeconds = _minSeconds + 1;
        }
    }

    public void StartTimer()
    {
        _triggerTime = GenerateTriggerTime();
        StartCoroutine(TimerRoutine(_triggerTime));
        Started?.Invoke();
    }

    private IEnumerator TimerRoutine(float triggerTime)
    {
        yield return new WaitForSeconds(triggerTime);
        TimeIsUp?.Invoke();
    }

    private float GenerateTriggerTime() =>
        UnityEngine.Random.Range(_minSeconds, _maxSeconds);
}
