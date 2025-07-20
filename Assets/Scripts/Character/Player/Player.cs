namespace Character.Player
{
    using System;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public event Action Died;

        private void OnCollisionEnter2D(Collision2D other) =>
            Died?.Invoke();
    }
}
