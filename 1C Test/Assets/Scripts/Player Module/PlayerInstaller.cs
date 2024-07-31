using Player_Module.Controllers;
using Player_Module.Observers;
using UI_Module;
using UI_Module.Health;
using Zenject;

namespace Player_Module
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<PlayerMoveController>()
                            .AsSingle();

            Container.BindInterfacesTo<PlayerClampInBorderController>()
                          .AsSingle();
            
            Container.BindInterfacesTo<PlayerDamagedObserver>()
                .AsSingle();
            
            Container.BindInterfacesTo<PlayerWinController>()
                .AsSingle();
            
            Container.BindInterfacesTo<PlayerLoseController>()
                .AsSingle();
            
            Container.Bind<HealthView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}