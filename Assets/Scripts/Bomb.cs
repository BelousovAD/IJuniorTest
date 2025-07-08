using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(RandomValueCoroutineTimer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SmoothVanisher))]
public class Bomb : PooledObject
{
    private Explosion _explosion;
    private RandomValueCoroutineTimer _timer;
    private Rigidbody _rigidbody;
    private SmoothVanisher _vanisher;

    private void Awake()
    {
        _explosion = GetComponent<Explosion>();
        _timer = GetComponent<RandomValueCoroutineTimer>();
        _rigidbody = GetComponent<Rigidbody>();
        _vanisher = GetComponent<SmoothVanisher>();
    }

    private void OnEnable()
    {
        _timer.Started += HandleTimerStart;
        _timer.TimeIsUp += Release;
        _timer.StartTimer();
        _rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        _timer.Started -= HandleTimerStart;
        _timer.TimeIsUp -= Release;
        _rigidbody.Sleep();
    }

    private void HandleTimerStart() =>
        _vanisher.StartVanish(_timer.TriggerTime);

    public override void Release()
    {
        _vanisher.StopVanish();
        _explosion.Explode(transform.position);
        base.Release();
    }
}
