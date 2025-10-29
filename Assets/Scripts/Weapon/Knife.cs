namespace Weapon
{
    using Character.Enemy;
    using UnityEngine;

    public class Knife : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _damage;
        [SerializeField] private PlayerTrigger _playerTrigger;

        private void OnEnable() =>
            _playerTrigger.ValueChanged += Damage;

        private void OnDisable() =>
            _playerTrigger.ValueChanged -= Damage;

        private void Damage() =>
            _playerTrigger.Value?.Health.TakeDamage(_damage);
    }
}