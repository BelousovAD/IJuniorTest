using System;
using UnityEngine;

public class CubeClickChecker : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    private Camera _camera;

    public event Action<Cube> CubeClicked;

    private void Awake() =>
        _camera = Camera.main;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Cube cube))
                {
                    CubeClicked?.Invoke(cube);
                }
            }
        }
    }
}
