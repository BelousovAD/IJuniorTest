namespace Pickable
{
    using System;
    using UnityEngine;

    public interface IPickable
    {
        public event Action<IPickable> Picked;

        public void PickUp();
    }
}
