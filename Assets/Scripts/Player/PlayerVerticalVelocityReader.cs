using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerVerticalVelocityReader : MonoBehaviour
{
    [SerializeField] private float _velocityEpsilon = 0.00001f;

    private Rigidbody2D _rigidbody2D;
    private bool _isFalling;
    private bool _isJumping;

    public event Action<bool> FallingStatusChanged;
    public event Action<bool> JumpingStatusChanged;

    private bool IsFalling
    {
        set
        {
            if (value != _isFalling)
            {
                _isFalling = value;
                FallingStatusChanged?.Invoke(_isFalling);
            }
        }
    }

    private bool IsJumping
    {
        set
        {
            if (value != _isJumping)
            {
                _isJumping = value;
                JumpingStatusChanged?.Invoke(_isJumping);
            }
        }
    }

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update()
    {
        IsFalling = _rigidbody2D.velocity.y < -_velocityEpsilon;
        IsJumping = _rigidbody2D.velocity.y > _velocityEpsilon;
    }
}
