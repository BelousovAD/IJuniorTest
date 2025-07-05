using System;
using Common.ChangeableValue;
using UnityEngine;

namespace Character.Player.ChangeableValue
{
    public class VerticalVelocity : ChangeableValueComponent<float>
    {
        public const float NeutralValue = 0f;

        [SerializeField] private float _velocityEpsilon = 0.001f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public override float Value
        {
            get => base.Value;
            protected set => base.Value = Mathf.Abs(value) > _velocityEpsilon ? value : NeutralValue;
        }

        private void FixedUpdate() =>
            Value = _rigidbody2D.velocity.y;
    }
}
