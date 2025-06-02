using System;
using System.Collections;
using UnityEngine;

public class RandomValueCoroutineTimer : MonoBehaviour
{
    [SerializeField] private float _minSeconds = 2;
    [SerializeField] private float _maxSeconds = 5;

    public event Action TimeIsUp;

    private void OnValidate()
    {
        if (_maxSeconds <= _minSeconds)
        {
            _maxSeconds = _minSeconds + 1;
        }
    }

    public void StartTimer() =>
        StartCoroutine(TimerRoutine(GenerateTriggerTime()));

    private IEnumerator TimerRoutine(float triggerTime)
    {
        yield return new WaitForSeconds(triggerTime);
        TimeIsUp?.Invoke();
    }

    private float GenerateTriggerTime() =>
        UnityEngine.Random.Range(_minSeconds, _maxSeconds);
}
