namespace Base
{
    using Currency;
    using Unit;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class GoldTaker : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _income = 1;
        [SerializeField] private Gold _gold;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit) && unit.Pickable is Item.Gold gold)
            {
                unit.Drop();
                _gold.Earn(_income);
                gold.Release();
            }
        }
    }
}