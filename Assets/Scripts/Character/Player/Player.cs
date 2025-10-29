namespace Character.Player
{
    using UnityEngine;

    public class Player : Character
    {
        protected override void Die()
        {
            Debug.LogError($"Health: {Health.Value}");
        }
    }
}