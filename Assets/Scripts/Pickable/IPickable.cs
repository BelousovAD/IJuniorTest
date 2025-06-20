namespace Pickable
{
    using System;
    using UnityEngine;

    public interface IPickable<T> where T : MonoBehaviour, IPickable<T>
    {
        public event Action<T> Picked;

        public void PickUp();
    }
}
