using UnityEngine;

[RequireComponent(typeof(RandomValueCoroutineTimer))]
[RequireComponent(typeof(SmoothVanisher))]
public class Bomb : PooledObject
{
    private RandomValueCoroutineTimer _timer;
    private SmoothVanisher _vanisher;

    private void Awake()
    {
        _timer = GetComponent<RandomValueCoroutineTimer>();
        _vanisher = GetComponent<SmoothVanisher>();
    }

    private void OnEnable()
    {
        _timer.Started += HandleTimerStart;
        _timer.TimeIsUp += Release;
        _timer.StartTimer();
    }

    private void OnDisable()
    {
        _timer.Started -= HandleTimerStart;
        _timer.TimeIsUp -= Release;
    }

    private void HandleTimerStart() =>
        _vanisher.StartVanish(_timer.TriggerTime);

    public override void Release()
    {
        _vanisher.StopVanish();
        base.Release();
    }
}
