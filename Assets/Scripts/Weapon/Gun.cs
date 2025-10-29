namespace Weapon
{
    using Character;
    using UnityEngine;

    public class Gun : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _damage;
        [SerializeField, Min(0f)] private float _maxShootDistance;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _startShootingPoint;

        public void Shoot()
        {
            if (Physics.Raycast(_startShootingPoint.position, _startShootingPoint.forward,
                    out RaycastHit hit, _maxShootDistance, _layerMask, QueryTriggerInteraction.UseGlobal)
                && hit.collider.TryGetComponent(out Character character))
            {
                character.Health.TakeDamage(_damage);
            }
        }
    }
}