namespace Fort
{
    using System.Collections.Generic;
    using ChangeableValue;
    using Common.ChangeableValue;
    using Common.Spawn;
    using UnityEngine;

    public class FortContainer : MonoBehaviour
    {
        [SerializeField] private Spawner _fortSpawner;
        [SerializeField] private List<Fort> _forts = new();
        
        public ChangeableList<Fort> Forts { get; } = new();

        public Selection Selection { get; } = new();

        private void Awake() =>
            _forts.ForEach(Add);

        private void OnEnable()
        {
            _fortSpawner.ComponentSpawned += Add;
            _fortSpawner.ComponentReleased += Remove;
            
            foreach (Fort fort in Forts)
            {
                fort.Selected += UpdateSelection;
            }
        }

        private void OnDisable()
        {
            _fortSpawner.ComponentSpawned -= Add;
            _fortSpawner.ComponentReleased -= Remove;
            
            foreach (Fort fort in Forts)
            {
                fort.Selected -= UpdateSelection;
            }
        }

        private void Add(Fort fort)
        {
            fort.Selected += UpdateSelection;
            Forts.Add(fort);
        }

        private void Add(PooledComponent pooledComponent) =>
            Add(pooledComponent as Fort);

        private void Remove(PooledComponent pooledComponent)
        {
            Fort fort = pooledComponent as Fort;
            fort!.Selected -= UpdateSelection;
            Forts.Remove(fort);
        }

        private void UpdateSelection(Fort fort) =>
            Selection.SetValue(fort);
    }
}