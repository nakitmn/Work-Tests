using Assets.Scripts.Input_Module;
using Zenject;

namespace Assets.Scripts
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<KeyboardPlayerInput>()
                .AsSingle();
        }
    }
}