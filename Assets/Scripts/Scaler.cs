using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private Vector3 _deltaScalePerSecond;

    private void Update()
    {
        Vector3 updatedScale = transform.localScale + _deltaScalePerSecond * Time.deltaTime;
        transform.localScale = updatedScale;
    }
}
