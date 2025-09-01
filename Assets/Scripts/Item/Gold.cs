namespace Item
{
    using Common.Spawn;
    using Pickable;
    using UnityEngine;
    using Random = UnityEngine.Random;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Gold : PooledComponent, IPickable
    {
        [SerializeField, Min(0)] private float _maxAngularVelocity = 7f;
        
        private Collider _collider;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = _maxAngularVelocity;
        }

        private void OnEnable() =>
            _rigidbody.AddRelativeTorque(Random.onUnitSphere * _maxAngularVelocity, ForceMode.Impulse);

        public void PickUp()
        {
            _collider.enabled = false;
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            _collider.enabled = true;
            _rigidbody.isKinematic = false;
        }
    }
}
