using System;
using UnityEngine;

public class ThiefTrigger : MonoBehaviour
{
    public event Action TriggerEnter;
    public event Action TriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            TriggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            TriggerExit?.Invoke();
        }
    }
}
