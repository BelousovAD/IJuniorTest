namespace Pickable
{
    using System;
    using UnityEngine;

    public class Picker : MonoBehaviour
    {
        public event Action<IPickable> Picking;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPickable pickable))
            {
                Picking?.Invoke(pickable);
                pickable.PickUp();
            }
        }
    }
}
