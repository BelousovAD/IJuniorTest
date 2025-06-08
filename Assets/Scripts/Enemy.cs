using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private MaterialSetter _materialSetter;

    public void Initialize(Material material, Transform targetToFollow, float moveSpeed)
    {
        _materialSetter.SetMaterial(material);
        SetTarget(targetToFollow);
        Mover.Speed = moveSpeed;
    }
}
