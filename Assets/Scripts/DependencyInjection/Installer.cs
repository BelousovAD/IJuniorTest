namespace DependencyInjection
{
    using Common.Spawn;
    using Fort;
    using UnityEngine;
    using Zenject;

    public class Installer : MonoInstaller
    {
        [SerializeField] private FortContainer _fortContainer;
        [SerializeField] private Spawner _fortSpawner;
        [SerializeField] private Spawner _unitSpawner;

        public override void InstallBindings()
        {
            Container.Bind<FortContainer>().FromInstance(_fortContainer);
            Container.Bind<Spawner>().WithId("Fort").FromInstance(_fortSpawner);
            Container.Bind<Spawner>().WithId("Unit").FromInstance(_unitSpawner);
        }
    }
}