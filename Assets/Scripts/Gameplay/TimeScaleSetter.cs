namespace Gameplay
{
    using UnityEngine;

    public class TimeScaleSetter : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _timeScale;
        [SerializeField] private bool _setOnEnable;
        [SerializeField] private bool _setOnDisable;

        private void OnEnable()
        {
            if (_setOnEnable)
            {
                Time.timeScale = _timeScale;
            }
        }

        private void OnDisable()
        {
            if (_setOnDisable)
            {
                Time.timeScale = _timeScale;
            }
        }
    }
}