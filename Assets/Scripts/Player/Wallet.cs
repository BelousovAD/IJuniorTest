using UnityEngine;

public class Wallet : MonoBehaviour
{
    private uint _currency;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _currency += coin.Value;
            Destroy(coin.gameObject);
        }
    }
}
