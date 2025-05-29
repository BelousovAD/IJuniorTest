using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    [SerializeField]
    private float _countDelayInSeconds = 0.5f;

    private bool _isWorking = false;
    private WaitUntil _waitUntilWork;
    private WaitForSecondsRealtime _waitForDelay;
    private int _count = 0;

    public event Action CountChanged;

    public int Count
    {
        get
        {
            return _count;
        }

        private set
        {
            _count = value;
            CountChanged?.Invoke();
        }
    }

    private void Awake()
    {
        _waitUntilWork = new WaitUntil(() => _isWorking);
        _waitForDelay = new WaitForSecondsRealtime(_countDelayInSeconds);
    }

    private void Start() =>
        StartCoroutine(CountRoutine());

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _isWorking = !_isWorking;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (isActiveAndEnabled)
        {
            yield return _waitForDelay;
            yield return _waitUntilWork;
            Count++;
        }
    }
}
