namespace Gameplay
{
    using Common.FiniteStateMachine;
    using Common.Spawn;
    using Currency;
    using Fort;
    using UnityEngine;

    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Fort _fort;
        [SerializeField] private Gold _gold;
        [SerializeField, Min(0)] private int _unitSpawnCost = 3;
        [SerializeField] private Spawner _unitSpawner;
        [SerializeField] private Transform _unitSpawnPoint;

        private FortStateMachineBuilder _fortStateMachineBuilder;
        private StateMachine _stateMachine;

        private void Start() =>
            InitializeFort();

        private void InitializeFort()
        {
            _fortStateMachineBuilder = new FortStateMachineBuilder(_gold,
                _unitSpawner,
                _unitSpawnCost,
                _unitSpawnPoint.position,
                _fort.AddUnit);
            _stateMachine = _fortStateMachineBuilder.Build();
            _fort.Initialize(_stateMachine);
        }
    }
}