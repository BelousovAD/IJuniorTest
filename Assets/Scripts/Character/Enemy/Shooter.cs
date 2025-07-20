namespace Character.Enemy
{
    using UnityEngine;

    public class Shooter : Character.Shooter
    {
        [SerializeField] private PlayerDetector _detector;
        
        private Coroutine _shooting;

        private void OnEnable() =>
            _detector.ValueChanged += Shoot;

        private void OnDisable() =>
            _detector.ValueChanged -= Shoot;

        private void Shoot()
        {
            if (_detector.Value)
            {
                _shooting = StartCoroutine(Shooting());
            }
            else
            {
                StopCoroutine(_shooting);
            }
        }
    }
}