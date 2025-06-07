using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimatorController : MonoBehaviour
{
    private readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private Mover _mover;

    private Animator _animator;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    private void OnEnable()
    {
        _mover.SpeedChanged += UpdateSpeedParameter;
        UpdateSpeedParameter(_mover.Speed);
    }

    private void OnDisable() =>
        _mover.SpeedChanged -= UpdateSpeedParameter;

    private void UpdateSpeedParameter(float speed) =>
        _animator.SetFloat(Speed, speed);
}
