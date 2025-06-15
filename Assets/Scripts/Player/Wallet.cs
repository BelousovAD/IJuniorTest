using UnityEngine;

public class Wallet : MonoBehaviour
{
    private uint _currency;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _currency += coin.Value;
            Destroy(coin.gameObject);
        }
    }
}
