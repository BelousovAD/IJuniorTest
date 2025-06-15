using System;
using UnityEngine;

public class PlayerIsOnGroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 0.1f;
    [SerializeField] private LayerMask _layersToRaycast;

    private RaycastHit2D _hitInfo;
    private bool _isOnGround;

    public event Action<bool> IsOnGroundStatusChanged;

    private void Update()
    {
        _hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _checkDistance, _layersToRaycast);

        if (_hitInfo.collider != null ^ _isOnGround)
        {
            _isOnGround = _hitInfo.collider != null;
            IsOnGroundStatusChanged?.Invoke(_isOnGround);
        }
    }
}
