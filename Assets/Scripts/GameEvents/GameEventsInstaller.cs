using Zenject;

namespace NS.GameEventsScripts
{
    public class GameEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameEvents>().FromNew().AsSingle();
        }
    }
}
