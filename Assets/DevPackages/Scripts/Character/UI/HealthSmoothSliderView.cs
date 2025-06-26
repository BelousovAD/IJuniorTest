namespace DevPackages.Character.UI
{
    using System.Collections;
    using UnityEngine;

    public class HealthSmoothSliderView : HealthSliderView
    {
        [SerializeField] private float _epsilon = 1e-5f;
        [SerializeField] private float _changingTimeInSeconds = 1;

        private float _targetValue;
        private float _changingSpeed;
        private Coroutine _changingValueSmoothly;

        protected override void UpdateView()
        {
            _targetValue = Parameter.Value;
            _changingSpeed = Mathf.Abs(_targetValue - Slider.value) / _changingTimeInSeconds;

            if (_changingValueSmoothly == null)
            {
                _changingValueSmoothly = StartCoroutine(ChangeValueSmoothly());
            }
        }

        private IEnumerator ChangeValueSmoothly()
        {
            while (isActiveAndEnabled && IsTargetReached() == false)
            {
                Slider.value = Mathf.MoveTowards(Slider.value, _targetValue, Time.deltaTime * _changingSpeed);

                yield return null;
            }

            Slider.value = _targetValue;
        }

        private bool IsTargetReached() =>
            Mathf.Abs(_targetValue - Slider.value) < _epsilon;
    }
}
