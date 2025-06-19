namespace Player
{
    using Currency.Coin;
    using UnityEngine;

    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Coin coin))
            {
                _wallet.EarnCurrency(coin.Value);
                coin.Collect();
            }
        }
    }
}
