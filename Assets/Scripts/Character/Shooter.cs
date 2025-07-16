using System.Collections;
using UnityEngine;
using Weapon.Bullet;

namespace Character
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private BulletSpawner _spawner;
        [SerializeField] private float _delayInSeconds;

        private bool _isReady = true;
        private WaitForSeconds _waitForCooldown;
        private WaitUntil _waitUntilReady;
        private Coroutine _coolingDown;

        protected IEnumerator Shooting()
        {
            while (isActiveAndEnabled)
            {
                yield return _waitUntilReady ??= new WaitUntil(() => _isReady);
                
                _spawner.Spawn();
                _coolingDown = StartCoroutine(CoolDown());
            }
        }

        private IEnumerator CoolDown()
        {
            _isReady = false;
            
            yield return _waitForCooldown ??= new WaitForSeconds(_delayInSeconds);

            _isReady = true;
        }
    }
}