using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        int verticalInput = Mathf.RoundToInt(Input.GetAxisRaw(Vertical));
        transform.Translate(verticalInput * _speed * Time.deltaTime * Vector3.forward);
    }
}
