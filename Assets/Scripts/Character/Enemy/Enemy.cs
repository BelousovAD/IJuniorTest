using Common.Pool;
using UnityEngine;
using Weapon.Bullet;

namespace Character.Enemy
{
    public class Enemy : PooledComponent
    {
        [SerializeField] private PlayerDetector _detector;

        public void Initialize(float distanceToCheck) =>
            _detector.Initialize(distanceToCheck);
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Bullet>(out _))
            {
                Release();
            }
        }
    }
}