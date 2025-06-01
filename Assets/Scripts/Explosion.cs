using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force = 1f;
    [SerializeField] private float _radius = 1f;

    public void Explode(List<Rigidbody> affectedObjects, Vector3 point)
    {
        foreach (Rigidbody rigidbody in affectedObjects)
        {
            rigidbody.AddExplosionForce(_force, point, _radius);
        }
    }

    public void Explode(Vector3 point, float forceMultiplier, float radiusMultiplier)
    {
        float force = _force * forceMultiplier;
        float radius = _radius * radiusMultiplier;
        List<Rigidbody> affectedRigidbodies = GetRigidbodiesFromExplosionSphere(point, radius);

        foreach (Rigidbody affectedRigidbody in affectedRigidbodies)
        {
            affectedRigidbody.AddExplosionForce(force, point, radius);
        }
    }

    private List<Rigidbody> GetRigidbodiesFromExplosionSphere(Vector3 point, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(point, radius);
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
