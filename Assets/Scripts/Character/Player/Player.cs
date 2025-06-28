namespace Character.Player
{
    using DevPackages.Character;
    using Pickable;
    using Pickable.Coin;
    using Pickable.Medicine;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Health _health;
        [SerializeField] private Picker _picker;

        public Health Health => _health;

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
