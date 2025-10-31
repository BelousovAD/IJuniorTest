namespace Character
{
    using FSM.States;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyLocker : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            _character.Initialized += Subscribe;
            Subscribe();
        }

        private void OnDisable() =>
            Unsubscribe();

        private void Subscribe()
        {
            if (_character.StateSwitcher is not null)
            {
                _character.Initialized -= Subscribe;
                _character.StateSwitcher.StateSwitched += UpdateRigidbody;
                UpdateRigidbody();
            }
        }

        private void Unsubscribe()
        {
            _character.Initialized -= Subscribe;

            if (_character.StateSwitcher is not null)
            {
                _character.StateSwitcher.StateSwitched -= UpdateRigidbody;
            }
        }

        private void UpdateRigidbody() =>
            _rigidbody.isKinematic = _character.StateSwitcher.CurrentState is AttackState;
    }
}