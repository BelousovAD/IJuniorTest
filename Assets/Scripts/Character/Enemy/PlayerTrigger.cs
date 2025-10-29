namespace Character.Enemy
{
    using System;
    using Common.ChangeableValue;
    using Player;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class PlayerTrigger : MonoBehaviour, IChangeableValue
    {
        private Player _value;
        
        public event Action ValueChanged;

        public Player Value
        {
            get
            {
                return _value;
            }

            private set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged?.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                Value = player;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player _))
            {
                Value = null;
            }
        }
    }
}