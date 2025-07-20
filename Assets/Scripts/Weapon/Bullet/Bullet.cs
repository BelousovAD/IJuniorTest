namespace Weapon.Bullet
{
    using Common.Pool;
    using UnityEngine;

    public class Bullet : PooledComponent
    {
        public Rigidbody2D Rigidbody { get; private set; }
        
        private void Awake() =>
            Rigidbody = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D() =>
            Release();
    }
}
