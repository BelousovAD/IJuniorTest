namespace DependencyInjection
{
    using Character.ChangeableValue;
    using Input;
    using UnityEngine;
    using Zenject;

    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField, Min(1f)] private float _maxPlayerHealth;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputReader>().To<PlayerInputReader>().AsSingle();
            Container.Bind<Health>().FromInstance(new Health(_maxPlayerHealth));
        }
    }
}