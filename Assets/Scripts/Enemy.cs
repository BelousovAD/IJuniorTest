using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private MaterialSetter _materialSetter;
    
    [SerializeField] private float _startSpeed = 1f;

    public void Initialize()
    {
        _mover.Speed = _startSpeed;
        _materialSetter.SetRandomMaterial();
    }
}
