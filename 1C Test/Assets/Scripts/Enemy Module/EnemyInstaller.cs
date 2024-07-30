using Enemy_Module.Observers;
using Zenject;

namespace Enemy_Module
{
    public sealed class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>()
                .AsSingle();

            Container.BindInterfacesTo<EnemyInBorderObserver>()
                .AsSingle();
        }
    }
}