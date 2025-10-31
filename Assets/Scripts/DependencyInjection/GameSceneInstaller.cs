namespace DependencyInjection
{
    using Character.ChangeableValue;
    using Gameplay;
    using UnityEngine;
    using Zenject;

    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField, Min(1f)] private float _maxPlayerHealth;
        [SerializeField] private WaveSpawnCaller _waveSpawnCaller;
        
        public override void InstallBindings()
        {
            Container.Bind<Health>().FromInstance(new Health(_maxPlayerHealth));
            Container.Bind<WaveSpawnCaller>().FromInstance(_waveSpawnCaller);
        }
    }
}