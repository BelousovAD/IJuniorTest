using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableObject : MonoBehaviour
{
    private const float DivisionChanceDivider = 2f;

    [SerializeField]
    private float _explosionRadius = 1f;
    [SerializeField]
    private float _explosionForce = 1f;

    private float _divisionChanceBoundary = 1f;

    public static event Action<ExplodableObject> Clicked;

    public void Initialize(ExplodableObject parent)
    {
        if (parent != null)
        {
            _divisionChanceBoundary = parent._divisionChanceBoundary / DivisionChanceDivider;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (UnityEngine.Random.value <= _divisionChanceBoundary)
        {
            Clicked?.Invoke(this);

            foreach (Rigidbody rigidbody in GetRigidbodiesFromExplosionSphere())
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private List<Rigidbody> GetRigidbodiesFromExplosionSphere()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> rigidbodies = new();
        Rigidbody attachedRigidbody;

        foreach (Collider collider in colliders)
        {
            attachedRigidbody = collider.attachedRigidbody;

            if (attachedRigidbody != null)
            {
                rigidbodies.Add(attachedRigidbody);
            }
        }

        return rigidbodies;
    }
}
