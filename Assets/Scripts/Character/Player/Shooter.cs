using Input;
using Input.ChangeableValue;
using UnityEngine;

namespace Character.Player
{
    public class Shooter : Character.Shooter
    {
        [SerializeField] private StandaloneInputReader _inputReader;

        private FireInput _fireInput;
        private Coroutine _shooting;

        protected void Awake() =>
            _fireInput = _inputReader.FireInput;

        private void OnEnable() =>
            _fireInput.ValueChanged += Shoot;

        private void OnDisable() =>
            _fireInput.ValueChanged -= Shoot;

        private void Shoot()
        {
            if (_fireInput.Value)
            {
                _shooting = StartCoroutine(Shooting());
            }
            else
            {
                StopCoroutine(_shooting);
            }
        }
    }
}