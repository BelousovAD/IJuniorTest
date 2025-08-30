namespace Item
{
    using Common.Spawn;
    using Pickable;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Gold : PooledComponent, IPickable
    {
        private Collider _collider;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void PickUp()
        {
            _collider.enabled = false;
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            _collider.enabled = true;
            _rigidbody.isKinematic = false;
            _rigidbody.Sleep();
        }
    }
}
