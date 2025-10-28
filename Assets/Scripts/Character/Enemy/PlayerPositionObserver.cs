namespace Character.Enemy
{
    using Common.ChangeableValue;
    using UnityEngine;

    public class PlayerPositionObserver : MonoBehaviour
    {
        [SerializeField] private Transform _transformFrom;
        [SerializeField, Min(0f)] private float _closeDistance;

        private float _sqrCloseDistance;
        private Transform _player;

        public ChangeableValue<bool> IsCloseEnough { get; } = new();

        public ChangeableValue<Vector2> Direction2D { get; } = new();

        public void Initialize(Transform player) =>
            _player = player;

        private void Awake() =>
            _sqrCloseDistance = _closeDistance * _closeDistance;

        private void Update()
        {
            Vector3 direction3D = _player.position - _transformFrom.position;
            IsCloseEnough.Value = Vector3.SqrMagnitude(direction3D) <= _sqrCloseDistance;
            Direction2D.Value = new Vector2(direction3D.x, direction3D.z).normalized;
        }
    }
}