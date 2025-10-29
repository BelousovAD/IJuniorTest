namespace Character.Enemy.ChangeableValue
{
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public class IsTransformCloseEnough : ChangeableValue<bool>, IUpdatable
    {
        private Transform _transformFrom;
        private Transform _transformTo;
        private float _sqrCloseDistance;
        private bool _isInitialized;
        
        public void Initialize(Transform from, Transform to, float closeDistance)
        {
            _transformFrom = from;
            _transformTo = to;
            _sqrCloseDistance = closeDistance * closeDistance;
            _isInitialized = true;
        }
        
        public void Update(float deltaTime)
        {
            if (_isInitialized)
            {
                Value = Vector3.SqrMagnitude(_transformTo.position - _transformFrom.position) <= _sqrCloseDistance;
            }
        }
    }
}