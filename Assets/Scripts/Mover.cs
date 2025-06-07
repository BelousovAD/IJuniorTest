using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float MinSpeed = 0f;

    private float _speed = 0f;

    public event Action<float> SpeedChanged;

    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = Mathf.Max(MinSpeed, value);
            SpeedChanged?.Invoke(_speed);
        }
    }

    private void Update() =>
        transform.Translate(Speed * Time.deltaTime * Vector3.forward, Space.Self);
}
