namespace DevPackages.Character.UI
{
    using DevPackages.UI;
    using UnityEngine;

    public class DamageButton : AbstractButton
    {
        [SerializeField] private Health _health;
        [SerializeField, Min(0)] private int _damage;

        protected override void HandleClick() =>
            _health.TakeDamage(_damage);
    }
}
