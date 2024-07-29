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
        }
    }
}