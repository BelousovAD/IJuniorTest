using Common.Pool;
using UnityEngine;

namespace Weapon.Bullet
{
    public class Bullet : PooledComponent
    {
        public Rigidbody2D Rigidbody { get; private set; }
        
        private void Awake() =>
            Rigidbody = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter(Collision other) =>
            Release();
    }
}
