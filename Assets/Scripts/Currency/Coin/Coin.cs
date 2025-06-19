namespace Currency.Coin
{
    using System;
    using UnityEngine;

    public class Coin : MonoBehaviour
    {
        [SerializeField] private uint _value;

        public event Action<Coin> Collected;

        public uint Value =>
            _value;

        public void Collect() =>
            Collected?.Invoke(this);
    }
}
