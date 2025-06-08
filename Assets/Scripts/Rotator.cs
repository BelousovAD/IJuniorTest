using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform Target { get; set; }

    private void Update()
    {
        if (Target != null)
        {
            transform.LookAt(Target, Vector3.up);
        }
    }
}
