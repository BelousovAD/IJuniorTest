using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
public class Character : MonoBehaviour
{
    protected Mover Mover;
    protected Rotator Rotator;

    protected void SetTarget(Transform target) =>
        Rotator.Target = target;

    protected virtual void Awake()
    {
        Mover = GetComponent<Mover>();
        Rotator = GetComponent<Rotator>();
    }
}
