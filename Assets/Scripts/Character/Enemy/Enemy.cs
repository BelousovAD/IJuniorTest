using Common.Pool;
using UnityEngine;
using Weapon.Bullet;

namespace Character.Enemy
{
    public class Enemy : PooledComponent
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Bullet>(out _))
            {
                Release();
            }
        }
    }
}