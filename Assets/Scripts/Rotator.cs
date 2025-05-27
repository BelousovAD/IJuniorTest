using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationAnglePerSecond;

    private void Update() =>
        transform.Rotate(_rotationAnglePerSecond * Time.deltaTime, Space.Self);
}
