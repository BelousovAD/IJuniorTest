using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private const float Duration = 1f;
    private const int LoopCount = -1;
    
    [SerializeField] private Vector3 _deltaScalePerSecond;

    private void Start()
    {
        transform.DOScale(transform.localScale + _deltaScalePerSecond, Duration)
            .SetLoops(LoopCount, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }
}
