using System;
using UnityEngine;

public class PlayerIsOnGroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 0.1f;
    [SerializeField] private Collider2D _playerCollider;

    private RaycastHit2D _hitInfo;
    private bool _isOnGround;

    public event Action<bool> IsOnGroundStatusChanged;

    private void Update()
    {
        _hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _checkDistance);

        if ((_hitInfo.collider != null && _hitInfo.collider != _playerCollider) ^ _isOnGround)
        {
            _isOnGround = _hitInfo.collider != null;
            IsOnGroundStatusChanged?.Invoke(_isOnGround);
        }
    }
}
