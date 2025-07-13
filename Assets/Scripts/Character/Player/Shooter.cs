using Input;
using Input.ChangeableValue;
using UnityEngine;
using Weapon.Bullet;

namespace Character.Player
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private StandaloneInputReader _inputReader;
        [SerializeField] private BulletSpawner _spawner;

        private FireInput _fireInput;

        private void Awake() =>
            _fireInput = _inputReader.FireInput;

        private void OnEnable() =>
            _fireInput.ValueChanged += Spawn;

        private void OnDisable() =>
            _fireInput.ValueChanged -= Spawn;

        private void Spawn()
        {
            if (_fireInput.Value)
            {
                _spawner.Spawn();
            }
        }
    }
}