using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _shootEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                _shootEffect.transform.position = hit.point;
                _shootEffect.transform.rotation =
                    Quaternion.FromToRotation(_shootEffect.transform.forward, hit.normal) *
                    _shootEffect.transform.rotation;
                _shootEffect.Play();
            }
        }
    }
}
