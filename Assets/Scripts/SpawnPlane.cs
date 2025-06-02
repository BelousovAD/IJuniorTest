using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    [SerializeField] private Vector3 _size = Vector3.one;

    public Vector3 Size =>
        _size;

    private Vector3 HalfSize =>
        _size / 2;

    public Vector3 GetRandomPoint()
    {
        Vector3 offset = new(
            Random.Range(-HalfSize.x, HalfSize.x),
            0f,
            Random.Range(-HalfSize.z, HalfSize.z));

        return transform.position + offset;
    }
}
