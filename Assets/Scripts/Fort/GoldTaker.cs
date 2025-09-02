namespace Fort
{
    using Currency;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class GoldTaker : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _income = 1;
        [SerializeField] private Gold _gold;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Item.Gold gold))
            {
                _gold.Earn(_income);
                gold.Release();
            }
        }
    }
}