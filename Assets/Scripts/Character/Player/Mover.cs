namespace Character.Player
{
    using Input;
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField, Min(0)] private float _movementSpeed;
        
        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private Vector3 _motion;

        private void Awake() =>
            _characterController = GetComponent<CharacterController>();

        private void OnEnable() =>
            _inputReader.MoveInputChanged += UpdateMotion;

        private void OnDisable() =>
            _inputReader.MoveInputChanged -= UpdateMotion;

        private void Update() =>
            _characterController.Move(_motion * Time.deltaTime);

        private void UpdateMotion()
        {
            if (_inputReader.MoveInput == Vector2.zero)
            {
                _motion = Vector3.zero;
            }
            else
            {
                _motion = transform.forward * _movementSpeed + Physics.gravity;
            }
        }
    }
}