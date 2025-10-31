namespace Character.Enemy
{
    using ChangeableValue;
    using Common;
    using Common.Behaviour;
    using Common.ChangeableValue;
    using UnityEngine;

    public class PlayerPositionObserver : MonoBehaviour, IEnable, IDisable
    {
        [SerializeField] private Transform _transformFrom;
        [SerializeField, Min(0f)] private float _closeDistance;

        private readonly IsTransformCloseEnough _isCloseEnough = new();
        private readonly Direction2 _direction2 = new();

        public ChangeableValue<bool> IsCloseEnough => _isCloseEnough;

        public ChangeableValue<Vector2> Direction2D => _direction2;

        public void Initialize(Transform player)
        {
            _isCloseEnough.Initialize(_transformFrom, player, _closeDistance);
            _direction2.Initialize(_transformFrom, player, AxisType.Y);
        }

        private void Update()
        {
            _isCloseEnough.Update(Time.deltaTime);
            _direction2.Update(Time.deltaTime);
        }

        public void Enable()
        {
            _isCloseEnough.Enable();
            _direction2.Enable();
        }

        public void Disable()
        {
            _isCloseEnough.Disable();
            _direction2.Disable();
        }

        public void ForgetDirection() =>
            _direction2.Disable();

        public void RemindDirection() =>
            _direction2.Enable();
    }
}