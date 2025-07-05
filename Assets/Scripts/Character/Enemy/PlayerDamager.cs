using System.Collections;
using Character.ChangeableValue;
using UnityEngine;

namespace Character.Enemy
{
    public class PlayerDamager : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _damage;
        [SerializeField, Min(0)] private float _delay;

        private WaitForSeconds _waitForDelay;
        private Coroutine _damageDealing;
        private Coroutine _waiting;

        private void Awake() =>
            _waitForDelay = new WaitForSeconds(_delay);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                if (_damageDealing == null)
                {
                    _damageDealing = StartCoroutine(DamageDealing(player));
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                if (_damageDealing != null)
                {
                    StopCoroutine(_damageDealing);
                    _damageDealing = null;
                }
            }
        }

        private IEnumerator DamageDealing(Player.Player player)
        {
            Health playerHealth = player.ChangeableValueContainer.Get<Health>();

            yield return _waiting;

            while (isActiveAndEnabled && playerHealth.Value > 0)
            {
                playerHealth.TakeDamage(_damage);

                yield return _waiting = StartCoroutine(Waiting());
            }
        }

        private IEnumerator Waiting()
        {
            yield return _waitForDelay;
        }
    }
}
