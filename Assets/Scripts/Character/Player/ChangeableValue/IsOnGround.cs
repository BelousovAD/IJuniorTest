using Common.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class IsOnGround : ChangeableValueComponent<bool>
    {
        [SerializeField] private float _checkDistance = 0.01f;
        [SerializeField] private LayerMask _layersToRaycast;

        private RaycastHit2D _hitInfo;

        private void Update()
        {
            _hitInfo = Physics2D.Raycast(
                transform.position,
                Vector2.down,
                _checkDistance,
                _layersToRaycast);

            if (_hitInfo.collider is not null ^ Value)
            {
                Value = _hitInfo.collider is not null;
            }
        }
    }
}
