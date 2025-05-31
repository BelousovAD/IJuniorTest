using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomMaterialSetter : MonoBehaviour
{
    private const float MinRandomValue = 0f;

    [SerializeField]
    private List<Material> _materials = new();

    private MeshRenderer _meshRenderer;

    private void Awake() =>
        _meshRenderer = GetComponent<MeshRenderer>();

    private void Start() =>
        _meshRenderer.material = _materials[(int)Random.Range(MinRandomValue, _materials.Count)];
}
