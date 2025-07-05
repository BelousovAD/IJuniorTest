using System;
using UnityEngine;

namespace Pickable.Medicine
{
    public class Medicine : MonoBehaviour, IPickable
    {
        [SerializeField, Min(0)] private int _value;

        public event Action<IPickable> Picked;

        public int Value =>
            _value;

        public void PickUp() =>
            Picked?.Invoke(this);
    }
}
