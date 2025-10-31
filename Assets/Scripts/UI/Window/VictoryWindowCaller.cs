namespace UI.Window
{
    using Gameplay;
    using UnityEngine;
    using Zenject;

    public class VictoryWindowCaller : MonoBehaviour
    {
        [SerializeField] private Window _parentWindow;
        [SerializeField] private string _windowToOpenId;
        
        private WaveSpawnCaller _waveSpawnCaller;

        [Inject]
        private void Initialize(WaveSpawnCaller waveSpawnCaller) =>
            _waveSpawnCaller = waveSpawnCaller;

        private void OnEnable() =>
            _waveSpawnCaller.Completed += RequestOpenWindow;

        private void OnDisable() =>
            _waveSpawnCaller.Completed -= RequestOpenWindow;

        private void RequestOpenWindow() =>
            _parentWindow.Open(_windowToOpenId, false);
    }
}