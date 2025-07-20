using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private const float Duration = 1f;
    private const int LoopCount = -1;
    
    [SerializeField] private Vector3 _deltaScalePerSecond;

    private void Start()
    {
        transform.DOScale(_deltaScalePerSecond, Duration)
            .SetRelative()
            .SetLoops(LoopCount, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }
}
