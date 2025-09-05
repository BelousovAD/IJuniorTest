namespace Fort
{
    using Common.FiniteStateMachine;
    using Common.Spawn;
    using Currency;
    using UnityEngine;

    public class FortInitializer : MonoBehaviour
    {
        [SerializeField] private Fort _fort;
        [SerializeField] private Gold _gold;
        [SerializeField, Min(0)] private int _fortSpawnCost = 5;
        [SerializeField, Min(0)] private int _unitSpawnCost = 3;
        [SerializeField] private Spawner _unitSpawner;
        [SerializeField] private Transform _unitSpawnPoint;

        private FortStateMachineBuilder _fortStateMachineBuilder;
        private StateMachine _stateMachine;

        private void Start() =>
            InitializeFort();

        private void InitializeFort()
        {
            _fortStateMachineBuilder = new FortStateMachineBuilder(_fort,
                _gold,
                _fortSpawnCost,
                _unitSpawnCost,
                _unitSpawner,
                _unitSpawnPoint);
            _stateMachine = _fortStateMachineBuilder.Build();
            _fort.Initialize(_stateMachine);
        }
    }
}