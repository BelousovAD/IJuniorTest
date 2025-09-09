namespace Gameplay
{
    using Common.Spawn;
    using Fort;
    using UnityEngine;

    public class FortSpawnCaller : MonoBehaviour
    {
        [SerializeField] private Spawner _fortSpawner;
        [SerializeField] private Ground _ground;
        [SerializeField] private FortContainer _fortContainer;

        private void OnEnable() =>
            _ground.Clicked += SpawnOrMoveFort;

        private void OnDisable() =>
            _ground.Clicked -= SpawnOrMoveFort;

        private void SpawnOrMoveFort(Vector3 position)
        {
            Fort selectedFort = _fortContainer.Selection.Value;
            
            if (selectedFort is null)
            {
                return;
            }
            
            Fort fortToBuild = selectedFort.FortToBuild.Value;
            
            if (fortToBuild is null)
            {
                fortToBuild = _fortSpawner.SpawnAt(position) as Fort;
                selectedFort.FortToBuild.SetValue(fortToBuild);
            }
            else
            {
                fortToBuild.transform.position = position;
            }
        }
    }
}