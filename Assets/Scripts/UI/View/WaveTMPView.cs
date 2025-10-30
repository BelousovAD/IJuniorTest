namespace UI.View
{
    using Gameplay;
    using Zenject;

    public class WaveTMPView : AbstractTMPView
    {
        private WaveSpawnCaller _waveSpawnCaller;

        [Inject]
        private void Initialize(WaveSpawnCaller waveSpawnCaller) =>
            _waveSpawnCaller = waveSpawnCaller;

        private void OnEnable()
        {
            _waveSpawnCaller.WaveIndexChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _waveSpawnCaller.WaveIndexChanged -= UpdateView;

        public override void UpdateView()
        {
            TextField.text = _waveSpawnCaller is null
                ? string.Empty
                : string.Format(Format, _waveSpawnCaller.WaveIndex + 1, _waveSpawnCaller.WaveCount);
        }
    }
}