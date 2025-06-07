using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private MaterialSetter _materialSetter;
    [SerializeField] private float _maxAbsStartRotation = 180f;
    [SerializeField] private float _startSpeed = 1f;

    public void Initialize()
    {
        Vector3 rotation = new(
            0f,
            Random.Range(-_maxAbsStartRotation, _maxAbsStartRotation),
            0f);
        transform.Rotate(rotation);
        _mover.Speed = _startSpeed;
        _materialSetter.SetRandomMaterial();
    }
}
