namespace Character.Player
{
    using Pickable.Medicine;
    using UnityEngine;

    public class MedicineCollector : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Medicine medicine))
            {
                _health.TakeHealing(medicine.Value);
                medicine.PickUp();
            }
        }
    }
}
