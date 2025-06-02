using UnityEngine;

[RequireComponent(typeof(RandomValueCoroutineTimer))]
[RequireComponent(typeof(MaterialSetter))]
public class Droplet : MonoBehaviour
{
    private bool _isTriggered = false;
    private RandomValueCoroutineTimer _timer;
    private MaterialSetter _materialSetter;
    private DropletSpawner _parentSpawner;

    public void Initialize(DropletSpawner parentSpawner) =>
        _parentSpawner = parentSpawner;

    private void Awake()
    {
        _timer = GetComponent<RandomValueCoroutineTimer>();
        _materialSetter = GetComponent<MaterialSetter>();
    }

    private void OnEnable() =>
        _timer.TimeIsUp += Release;

    private void OnDisable() =>
        _timer.TimeIsUp -= Release;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTriggered)
        {
            return;
        }

        if (collision.gameObject.CompareTag(gameObject.tag) == false)
        {
            _isTriggered = true;
            _timer.StartTimer();
            _materialSetter.SetRandomMaterial();
        }
    }

    private void Release()
    {
        _isTriggered = false;
        _materialSetter.ResetMaterial();
        _parentSpawner.Release(this);
    }
}
