namespace Pickable.Medicine
{
    using System;
    using UnityEngine;

    public class Medicine : MonoBehaviour, IPickable<Medicine>
    {
        [SerializeField, Min(0)] private int _value;

        public event Action<Medicine> Picked;

        public int Value =>
            _value;

        public void PickUp() =>
            Picked?.Invoke(this);
    }
}
