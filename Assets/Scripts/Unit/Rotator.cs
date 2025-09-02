namespace Unit
{
    using UnityEngine;

    public class Rotator : MonoBehaviour
    {
        private Transform _target;
        
        private void Update()
        {
            if (_target is not null)
            {
                transform.forward = Vector3.ProjectOnPlane(
                        _target.position - transform.position,
                        Vector3.up)
                    .normalized;
            }
        }
        
        public void SetTarget(Transform target) =>
            _target = target;
    }
}