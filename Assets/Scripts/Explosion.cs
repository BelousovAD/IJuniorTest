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
}
