namespace Weapon.Bullet
{
    using Common.Spawn;
    using UnityEngine;

    public class BulletSpawner : Spawner
    {
        [SerializeField] private RectTransform _character;
        [SerializeField] private RectTransform _spawnPoint;
        [SerializeField] private Vector2 _defaultShotDirection;
        [SerializeField] private float _shotForce;

        private Vector2 _shootDirection;

        protected override void Awake()
        {
            base.Awake();
            Parent = _character.parent;
        }

        public void Spawn()
        {
            Bullet bullet = SpawnAt(_spawnPoint.position) as Bullet;
            Rigidbody2D bulletRigidbody = bullet!.Rigidbody;
            _shootDirection = Quaternion.AngleAxis(_character.eulerAngles.z, Vector3.forward) * _defaultShotDirection; 
            bulletRigidbody.AddForce(_shootDirection.normalized * _shotForce);
        }
    }
}