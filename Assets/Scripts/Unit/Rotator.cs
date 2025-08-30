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
                transform.LookAt(_target);
            }
        }
        
        public void SetTarget(Transform target) =>
            _target = target;
    }
}