namespace Character.Player
{
    using Pickable.Coin;
    using UnityEngine;

    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Coin coin))
            {
                _wallet.EarnMoney(coin.Value);
                coin.PickUp();
            }
        }
    }
}
