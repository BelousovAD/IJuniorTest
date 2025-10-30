namespace Character.Player
{
    using ChangeableValue;
    using UnityEngine;
    using Zenject;

    public class Player : Character
    {
        [Inject]
        private void Initialize(Health health) =>
            Health = health;
        
        protected override void Die()
        {
            Debug.LogError($"Health: {Health.Value}");
        }
    }
}