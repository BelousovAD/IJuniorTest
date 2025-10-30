namespace Weapon
{
    using Character;
    using Character.Enemy;
    using Character.FSM.States;
    using UnityEngine;

    public class Knife : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField, Min(0f)] private float _damage;
        [SerializeField] private PlayerTrigger _playerTrigger;
        
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
                _playerTrigger.ValueChanged += Damage;
                _character.StateSwitcher.StateSwitched += ChangeTriggerActivity;
                ChangeTriggerActivity();
            }
        }

        private void Unsubscribe()
        {
            _character.Initialized -= Subscribe;

            if (_character.StateSwitcher is not null)
            {
                _character.StateSwitcher.StateSwitched -= ChangeTriggerActivity;
                _playerTrigger.ValueChanged -= Damage;
            }
        }

        private void ChangeTriggerActivity() =>
            _playerTrigger.enabled = _character.StateSwitcher.CurrentState is AttackState;

        private void Damage()
        {
            _playerTrigger.Value?.Health.TakeDamage(_damage);
            _playerTrigger.enabled = false;
        }
    }
}