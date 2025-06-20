namespace Enemy
{
    using Player;
    using System;
    using UnityEngine;

    public class PlayerTrigger : MonoBehaviour
    {
        private Player _player;

        public event Action Triggered;

        public Player Player =>
            _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _player))
            {
                Triggered?.Invoke();
            }
        }
    }
}
