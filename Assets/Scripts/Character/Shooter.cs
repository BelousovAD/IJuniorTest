namespace Character
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using UnityEngine;
    using Weapon.Bullet;

    public class Shooter : MonoBehaviour
    {
        [SerializeField] private BulletSpawner _spawner;
        [SerializeField] private float _delayInSeconds;

        private WaitUntil _waitUntilReady;
        private Task _cooldown;

        protected IEnumerator Shooting()
        {
            while (isActiveAndEnabled)
            {
                yield return _waitUntilReady ??= new WaitUntil(() => _cooldown is null || _cooldown.IsCompleted);

                _spawner.Spawn();
                _cooldown = Task.Delay(TimeSpan.FromSeconds(_delayInSeconds));
            }
        }
    }
}