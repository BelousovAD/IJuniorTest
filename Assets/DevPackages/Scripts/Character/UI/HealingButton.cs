namespace DevPackages.Character.UI
{
    using DevPackages.UI;
    using UnityEngine;

    public class HealingButton : AbstractButton
    {
        [SerializeField] private Health _health;
        [SerializeField, Min(0)] private int _healing;

        protected override void HandleClick() =>
            _health.TakeHealing(_healing);
    }
}
