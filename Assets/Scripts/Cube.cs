using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private const float DivisionChanceDivider = 2f;
    private const float MinRandomValue = 0f;

    [SerializeField] private List<Material> _materials = new();

    private MeshRenderer _meshRenderer;

    public float DivisionChanceBoundary { get; private set; } = 1f;

    private void Awake() =>
        _meshRenderer = GetComponent<MeshRenderer>();

    private void Start() =>
        _meshRenderer.material = _materials[(int)Random.Range(MinRandomValue, _materials.Count)];

    public void Initialize(Cube parent)
    {
        if (parent != null)
        {
            DivisionChanceBoundary = parent.DivisionChanceBoundary / DivisionChanceDivider;
        }
    }
}
