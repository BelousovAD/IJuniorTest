namespace Character.Player
{
    using Pickable;
    using Pickable.Coin;
    using Pickable.Medicine;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private PlayerHealth _health;
        [SerializeField] private Picker _picker;

        private void OnEnable() =>
            _picker.Picking += PickUpHandle;

        private void OnDisable() =>
            _picker.Picking -= PickUpHandle;

        private void PickUpHandle(IPickable pickable)
        {
            if (pickable is Coin coin)
            {
                _wallet.EarnMoney(coin.Value);
            }
            else if (pickable is Medicine medicine)
            {
                _health.TakeHealing(medicine.Value);
            }
        }
    }
}
