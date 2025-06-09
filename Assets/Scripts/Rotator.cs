using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speedInEulerAngle = 90f;

    private void Update()
    {
        int horizontalInput = Mathf.RoundToInt(Input.GetAxisRaw(Horizontal));
        transform.Rotate(horizontalInput * _speedInEulerAngle * Time.deltaTime * Vector3.up);
    }
}
