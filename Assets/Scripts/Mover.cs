using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float Duration = 1f;
    private const int LoopCount = -1;
    
    [SerializeField] private float _speed;

    private void Start() =>
        transform.DOLocalMove(transform.localPosition + transform.forward * _speed, Duration)
            .SetLoops(LoopCount, LoopType.Incremental)
            .SetEase(Ease.Linear);
}
