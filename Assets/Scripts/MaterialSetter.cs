using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaterialSetter : MonoBehaviour
{
    private SkinnedMeshRenderer _meshRenderer;

    private void Awake() =>
        _meshRenderer = GetComponent<SkinnedMeshRenderer>();

    public void SetMaterial(Material material) =>
        _meshRenderer.material = material;
}
