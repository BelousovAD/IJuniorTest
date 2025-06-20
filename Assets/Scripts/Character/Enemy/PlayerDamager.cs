namespace Character.Enemy
{
    using Character.Player;
    using System.Collections;
    using UnityEngine;

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
            if (collision.TryGetComponent(out PlayerHealth playerHealth))
            {
                if (_damageDealing == null)
                {
                    _damageDealing = StartCoroutine(DamageDealing(playerHealth));
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerHealth _))
            {
                if (_damageDealing != null)
                {
                    StopCoroutine(_damageDealing);
                    _damageDealing = null;
                }
            }
        }

        private IEnumerator DamageDealing(PlayerHealth playerHealth)
        {
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
