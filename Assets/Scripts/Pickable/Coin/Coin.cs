namespace Pickable.Coin
{
    using System;
    using UnityEngine;

    public class Coin : MonoBehaviour, IPickable<Coin>
    {
        [SerializeField, Min(0)] private int _value;

        public event Action<Coin> Picked;

        public int Value =>
            _value;

        public void PickUp() =>
            Picked?.Invoke(this);
    }
}
