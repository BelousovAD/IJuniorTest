using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const float Duration = 1f;
    private const int LoopCount = -1;
    
    [SerializeField] private Vector3 _rotationAnglePerSecond;

    private void Start() =>
        transform.DOLocalRotate(transform.localEulerAngles + _rotationAnglePerSecond, Duration)
            .SetLoops(LoopCount, LoopType.Incremental)
            .SetEase(Ease.Linear);
}
