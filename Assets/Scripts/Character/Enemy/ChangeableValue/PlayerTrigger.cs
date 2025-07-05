using Common.ChangeableValue;
using UnityEngine;

namespace Character.Enemy.ChangeableValue
{
    public class PlayerTrigger : ChangeableValueComponent<bool>
    {
        private Player.Player _player;

        public Player.Player Player =>
            _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _player))
            {
                Value = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _player))
            {
                Value = false;
            }
        }
    }
}
