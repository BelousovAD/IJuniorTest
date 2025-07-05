using System;

namespace Pickable
{
    public interface IPickable
    {
        public event Action<IPickable> Picked;

        public void PickUp();
    }
}
