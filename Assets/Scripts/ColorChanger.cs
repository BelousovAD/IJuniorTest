using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private const int LoopCount = -1;
    
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    
    private Material _material;

    private void Awake() =>
        _material = GetComponent<MeshRenderer>().material;

    private void Start()
    {
        _material.DOColor(_targetColor, _duration)
            .SetLoops(LoopCount, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}