namespace Character.Player
{
    using Input;
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField, Min(0)] private float _speed;
        
        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private Vector3 _motion = Vector3.zero;

        private void Awake() =>
            _characterController = GetComponent<CharacterController>();

        private void OnEnable() =>
            _inputReader.MoveInputChanged += UpdateMotion;

        private void OnDisable() =>
            _inputReader.MoveInputChanged -= UpdateMotion;

        private void Update() =>
            _characterController.SimpleMove(_motion);

        private void UpdateMotion()
        {
            _moveDirection = new Vector3(_inputReader.MoveInput.x, 0f, _inputReader.MoveInput.y);
            _motion = _moveDirection * _speed;
        }
    }
}