using Common.ChangeableValue;
using UnityEngine;

namespace Character.Enemy
{
    public class PlayerDetector : ChangeableValueComponent<bool>
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private LayerMask _layersToRaycast;

        private float _checkDistance;
        private RaycastHit2D _hitInfo;

        private void Update()
        {
            _hitInfo = Physics2D.Raycast(transform.position, _direction, _checkDistance, _layersToRaycast);
            Debug.DrawRay(transform.position, _direction * _checkDistance);
            Value = _hitInfo.collider is not null && _hitInfo.collider.TryGetComponent<Player.Player>(out _);
        }

        public void Initialize(float checkDistance) =>
            _checkDistance = checkDistance;
    }
}