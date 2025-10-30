namespace Weapon
{
    using System.Collections;
    using Character;
    using Character.FSM.States;
    using UnityEngine;

    public class Gun : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField, Min(0f)] private float _delayBeforeShoot = 0.25f;
        [SerializeField, Min(0f)] private float _damage;
        [SerializeField, Min(0f)] private float _maxShootDistance;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _startShootingPoint;

        private WaitForSeconds _delay;

        private void Awake() =>
            _delay = new WaitForSeconds(_delayBeforeShoot);

        private void OnEnable()
        {
            _character.Initialized += Subscribe;
            Subscribe();
        }

        private void OnDisable() =>
            Unsubscribe();

        private void Subscribe()
        {
            if (_character.StateSwitcher is not null)
            {
                _character.Initialized -= Subscribe;
                _character.StateSwitcher.StateSwitched += Shoot;
                Shoot();
            }
        }

        private void Unsubscribe()
        {
            _character.Initialized -= Subscribe;

            if (_character.StateSwitcher is not null)
            {
                _character.StateSwitcher.StateSwitched -= Shoot;
            }
        }

        private void Shoot()
        {
            if (_character.StateSwitcher.CurrentState is AttackState)
            {
                StartCoroutine(ShootAfterDelay());
            }
        }

        private IEnumerator ShootAfterDelay()
        {
            yield return _delay;

            if (Physics.Raycast(_startShootingPoint.position, _startShootingPoint.forward,
                    out RaycastHit hit, _maxShootDistance, _layerMask, QueryTriggerInteraction.UseGlobal)
                && hit.collider.TryGetComponent(out Character character))
            {
                character.Health.TakeDamage(_damage);
            }
        }
    }
}