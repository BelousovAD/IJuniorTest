namespace Pickable
{
    using System;
    using UnityEngine;

    public class Picker : MonoBehaviour
    {
        public event Action<IPickable> Picking;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IPickable pickable))
            {
                Picking?.Invoke(pickable);
            }
        }
    }
}