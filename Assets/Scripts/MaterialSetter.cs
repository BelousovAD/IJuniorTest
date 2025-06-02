using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialSetter : MonoBehaviour
{
    private const int MinRandomValue = 0;

    [SerializeField]
    private List<Material> _materials = new();

    private MeshRenderer _meshRenderer;
    private readonly System.Random _random = new();

    private void Awake() =>
        _meshRenderer = GetComponent<MeshRenderer>();

    public void SetRandomMaterial() =>
        _meshRenderer.material = _materials[_random.Next(MinRandomValue, _materials.Count)];
}
