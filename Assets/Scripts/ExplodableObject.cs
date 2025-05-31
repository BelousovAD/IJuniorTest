using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableObject : MonoBehaviour
{
    public static event Action<Transform> Clicked;

    [SerializeField]
    private float _explosionRadius = 1f;
    [SerializeField]
    private float _explosionForce = 1f;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke(transform);

        foreach (Rigidbody rigidbody in GetRigidbodiesFromExplosionSphere())
        {
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
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
