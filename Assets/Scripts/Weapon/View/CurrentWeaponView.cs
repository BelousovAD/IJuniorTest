namespace Weapon.View
{
    using Character;
    using UnityEngine;

    public class CurrentWeaponView : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private GameObject _gun;
        [SerializeField] private GameObject _sword;

        private void OnEnable() =>
            UpdateView();

        private void UpdateView()
        {
            _gun.SetActive(false);
            _sword.SetActive(false);
            
            if (_character.HasGun)
            {
                _gun.SetActive(true);
            }
            else
            {
                _sword.SetActive(true);
            }
        }
    }
}