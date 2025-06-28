using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SmoothVanisher : MonoBehaviour
{
    private const float MinAlpha = 0f;

    [SerializeField] private float _epsilon = 1e-5f;

    private Color _defaultColor;
    private Coroutine _vanish;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _defaultColor = _material.color;
    }

    public void StartVanish(float duration)
    {
        StopVanish();
        _vanish = StartCoroutine(VanishSmoothly(duration));
    }

    public void StopVanish()
    {
        if (_vanish != null)
        {
            StopCoroutine(_vanish);
        }

        _vanish = null;
        _material.color = _defaultColor;
    }

    private IEnumerator VanishSmoothly(float duration)
    {
        float changingSpeed = _defaultColor.a - MinAlpha / duration;

        while (isActiveAndEnabled && IsTargetReached() == false)
        {
            _material.color = new Color(
                _defaultColor.r,
                _defaultColor.g,
                _defaultColor.b,
                Mathf.MoveTowards(_material.color.a, MinAlpha, Time.deltaTime * changingSpeed));

            yield return null;
        }
    }

    private bool IsTargetReached() =>
        _material.color.a - MinAlpha < _epsilon;
}
