using System.Collections.Generic;
using UnityEngine;

namespace Bomb
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _force = 1f;
        [SerializeField] private float _radius = 1f;

        public void Explode(Vector3 point)
        {
            List<Rigidbody> affectedRigidbodies = GetRigidbodiesFromExplosionSphere(point, _radius);
        
            foreach (Rigidbody rigidbody in affectedRigidbodies)
            {
                rigidbody.AddExplosionForce(_force, point, _radius);
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

                if (attachedRigidbody is not null)
                {
                    rigidbodies.Add(attachedRigidbody);
                }
            }

            return rigidbodies;
        }
    }
}