namespace DependencyInjection
{
    using Input;
    using Zenject;

    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputReader>().To<PlayerInputReader>().AsSingle();
        }
    }
}