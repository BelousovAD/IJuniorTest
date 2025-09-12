using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class SeesawMotor : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _duration;
    [SerializeField] private KeyCode _actionKey;
    
    private HingeJoint _hinge;

    private void Awake() =>
        _hinge = GetComponent<HingeJoint>();

    private void Update()
    {
        if (Input.GetKeyDown(_actionKey))
        {
            StartCoroutine(Work());
        }
    }

    private IEnumerator Work()
    {
        _hinge.useMotor = true;
        yield return new WaitForSeconds(_duration);
        _hinge.useMotor = false;
    }
}
