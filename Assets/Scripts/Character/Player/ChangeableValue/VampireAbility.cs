using System.Collections;
using System.Collections.Generic;
using Character.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class VampireAbility : Ability
    {
        [SerializeField] private Player _player;
        [SerializeField, Min(0)] private float _healSpeed;
        
        private readonly List<Enemy.Enemy> _enemies = new();
        private Health _playerHealth;
        private Coroutine _damageDealing;

        protected override void Awake()
        {
            base.Awake();
            _playerHealth = _player.ChangeableValueContainer.Get<Health>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                if (_enemies.Contains(enemy) == false)
                {
                    _enemies.Add(enemy);
                }
            }
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                _enemies.Remove(enemy);
            }
        }

        protected override void Activate()
        {
            _damageDealing = StartCoroutine(DamageDealing());
            base.Activate();
        }

        protected override void Deactivate()
        {
            StopCoroutine(_damageDealing);
            base.Deactivate();
        }

        private IEnumerator DamageDealing()
        {
            Enemy.Enemy enemyToDamage;
            Health enemyHealth;
            
            while (isActiveAndEnabled)
            {
                enemyToDamage = FindNearestEnemy();

                if (enemyToDamage is not null)
                {
                    enemyHealth = enemyToDamage.ChangeableValueContainer.Get<Health>();

                    if (enemyHealth.Value > 0)
                    {
                        enemyHealth.TakeDamage(_healSpeed * Time.deltaTime);
                        _playerHealth.TakeHealing(_healSpeed * Time.deltaTime);
                    }
                }

                yield return null;
            }
        }

        private Enemy.Enemy FindNearestEnemy()
        {
            if (_enemies.Count == 0)
            {
                return null;
            }
            
            Enemy.Enemy nearestEnemy = _enemies[0];
            float sqrDistance = Vector3.SqrMagnitude(nearestEnemy.transform.position - transform.position);
            float temporarySqrDistance;
            
            for (int i = 1; i < _enemies.Count; i++)
            {
                temporarySqrDistance = Vector3.SqrMagnitude(_enemies[i].transform.position - transform.position);
                
                if (sqrDistance < temporarySqrDistance)
                {
                    nearestEnemy = _enemies[i];
                    sqrDistance = temporarySqrDistance;
                }
            }

            return nearestEnemy;
        }
    }
}
