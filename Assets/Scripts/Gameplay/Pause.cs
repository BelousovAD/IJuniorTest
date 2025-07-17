using UnityEngine;

namespace Gameplay
{
    public class Pause : MonoBehaviour
    {
        private const float MinTimeScale = 0f;
        
        private float _cachedValue;
        
        private void OnEnable()
        {
            _cachedValue = Time.timeScale;
            Time.timeScale = MinTimeScale;
        }

        private void OnDisable() =>
            Time.timeScale = _cachedValue;
    }
}