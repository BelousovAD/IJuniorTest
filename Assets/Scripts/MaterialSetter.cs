using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaterialSetter : MonoBehaviour
{
    private const int MinRandomValue = 0;

    [SerializeField]
    private List<Material> _materials = new();

    private SkinnedMeshRenderer _meshRenderer;

    private void Awake() =>
        _meshRenderer = GetComponent<SkinnedMeshRenderer>();

    public void SetRandomMaterial() =>
        _meshRenderer.material = _materials[Random.Range(MinRandomValue, _materials.Count)];
}
