namespace Gameplay
{
    using System;
    using Common.Spawn;
    using Fort;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class FortSpawnCaller : MonoBehaviour, IPointerClickHandler
    {
        private static FortSpawnCaller _selectedInstance;
        
        [SerializeField] private Fort _fort;
        [SerializeField] private Spawner _fortSpawner;

        private Fort _lastSpawnedFort;

        private void OnEnable() =>
            Ground.Clicked += SpawnOrMoveFort;

        private void OnDisable() =>
            Ground.Clicked -= SpawnOrMoveFort;

        public void OnPointerClick(PointerEventData eventData) =>
            _selectedInstance = this;

        private void SpawnOrMoveFort(Vector3 position)
        {
            if (_selectedInstance == this)
            {
                if (_fort.FortToBuild.Value is null)
                {
                    _lastSpawnedFort = _fortSpawner.SpawnAt(position) as Fort;
                    _fort.FortToBuild!.SetValue(_lastSpawnedFort);
                }
                else
                {
                    _lastSpawnedFort.transform.position = position;
                }
            }
        }
    }
}