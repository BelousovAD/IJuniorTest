namespace Character.Enemy.ChangeableValue
{
    using Common;
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public class Direction2 : ChangeableValue<Vector2>, IEnable, IDisable, IUpdatable
    {
        private Transform _transformFrom;
        private Transform _transformTo;
        private AxisType _axisToExclude;
        private bool _isActive;
        private bool _isInitialized;
        
        public void Initialize(Transform from, Transform to, AxisType axisToExclude)
        {
            _transformFrom = from;
            _transformTo = to;
            _axisToExclude = axisToExclude;
            _isInitialized = true;
        }

        public void Enable()
        {
            Value = Vector2.zero;
            _isActive = true;
        }

        public void Disable()
        {
            _isActive = false;
            Value = Vector2.zero;
        }

        public void Update(float deltaTime)
        {
            if (_isInitialized && _isActive)
            {
                Vector3 direction3 = _transformTo.position - _transformFrom.position;

                Value = _axisToExclude switch
                {
                    AxisType.X => new Vector2(direction3.z, direction3.y),
                    AxisType.Y => new Vector2(direction3.x, direction3.z),
                    AxisType.Z => new Vector2(direction3.x, direction3.y),
                    _ => Vector2.zero,
                };
            }
        }
    }
}