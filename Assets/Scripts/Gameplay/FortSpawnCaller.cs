namespace Gameplay
{
    using Common.Spawn;
    using Fort;
    using UnityEngine;

    public class FortSpawnCaller : MonoBehaviour
    {
        [SerializeField] private Spawner _fortSpawner;
        [SerializeField] private Ground _ground;

        private Fort _selectedFort;

        private void OnEnable()
        {
            _ground.Clicked += SpawnOrMoveFort;
            Fort.Selected += SetSelectedFort;
        }

        private void OnDisable()
        {
            _ground.Clicked -= SpawnOrMoveFort;
            Fort.Selected -= SetSelectedFort;
        }

        private void SetSelectedFort(Fort fort) =>
            _selectedFort = fort;

        private void SpawnOrMoveFort(Vector3 position)
        {
            if (_selectedFort is null)
            {
                return;
            }
            
            Fort fortToBuild = _selectedFort.FortToBuild.Value;
            
            if (fortToBuild is null)
            {
                fortToBuild = _fortSpawner.SpawnAt(position) as Fort;
                _selectedFort.FortToBuild.SetValue(fortToBuild);
            }
            else
            {
                fortToBuild.transform.position = position;
            }
        }
    }
}