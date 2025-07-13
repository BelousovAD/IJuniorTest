using Common.Spawn;
using UnityEngine;

namespace Weapon.Bullet
{
    public class BulletSpawner : Spawner
    {
        [SerializeField] private RectTransform _character;
        [SerializeField] private RectTransform _spawnPoint;
        [SerializeField] private Vector2 _shotDirection;
        [SerializeField] private float _shotForce;

        protected override void Awake()
        {
            base.Awake();
            Parent = _character.parent;
        }

        public void Spawn()
        {
            Bullet bullet = SpawnAt(_spawnPoint.position) as Bullet;
            Rigidbody2D bulletRigidbody = bullet!.Rigidbody;
            bulletRigidbody.AddForce(_shotDirection * _shotForce);
        }
    }
}