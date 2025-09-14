using Input;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Vector3 _pushForce;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable() =>
        _inputReader.PushRequested += Push;

    private void OnDisable() =>
        _inputReader.PushRequested -= Push;

    private void Push() =>
        _rigidbody.AddForce(_pushForce);
}
