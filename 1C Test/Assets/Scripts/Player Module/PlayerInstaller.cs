using Assets.Scripts.UI_Module;
using Zenject;

namespace Assets.Scripts.Player_Module
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
            
            Container.Bind<HealthView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}