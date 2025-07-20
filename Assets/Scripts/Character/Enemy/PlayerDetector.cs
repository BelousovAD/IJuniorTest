namespace Character.Enemy
{
    using Common.ChangeableValue;
    using Player;
    using UnityEngine;

    public class PlayerDetector : ChangeableValueComponent<bool>
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private LayerMask _layersToRaycast;

        private float _distanceToCheck;
        private RaycastHit2D _hitInfo;

        private void Update()
        {
            _hitInfo = Physics2D.Raycast(
                transform.position,
                _direction,
                _distanceToCheck,
                _layersToRaycast);
            Debug.DrawRay(transform.position, _direction * _distanceToCheck);
            Value = _hitInfo.collider is not null && _hitInfo.collider.TryGetComponent<Player>(out _);
        }

        public void Initialize(float distanceToCheck) =>
            _distanceToCheck = distanceToCheck;
    }
}