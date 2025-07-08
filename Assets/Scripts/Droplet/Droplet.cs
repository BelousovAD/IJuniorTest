using Common;
using UnityEngine;

namespace Droplet
{
    [RequireComponent(typeof(RandomValueCoroutineTimer))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MaterialSetter))]
    public class Droplet : PooledObject
    {
        private bool _isTriggered = false;
        private RandomValueCoroutineTimer _timer;
        private Rigidbody _rigidbody;
        private MaterialSetter _materialSetter;

        private void Awake()
        {
            _timer = GetComponent<RandomValueCoroutineTimer>();
            _rigidbody = GetComponent<Rigidbody>();
            _materialSetter = GetComponent<MaterialSetter>();
        }

        private void OnEnable()
        {
            _timer.TimeIsUp += Release;
            _rigidbody.WakeUp();
        }

        private void OnDisable()
        {
            _timer.TimeIsUp -= Release;
            _rigidbody.Sleep();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isTriggered)
            {
                return;
            }

            if (collision.gameObject.CompareTag(gameObject.tag) == false)
            {
                _isTriggered = true;
                _timer.StartTimer();
                _materialSetter.SetRandomMaterial();
            }
        }

        public override void Release()
        {
            _isTriggered = false;
            _materialSetter.ResetMaterial();
            base.Release();
        }
    }
}
