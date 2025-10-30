namespace DependencyInjection
{
    using Gameplay;
    using UnityEngine;
    using Zenject;

    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private WaveSpawnCaller _waveSpawnCaller;
        
        public override void InstallBindings()
        {
            Container.Bind<WaveSpawnCaller>().FromInstance(_waveSpawnCaller);
        }
    }
}