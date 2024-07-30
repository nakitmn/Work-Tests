using Assets.Scripts.Border_Module;
using Assets.Scripts.Bullet_Module;
using Assets.Scripts.Input_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<KeyboardPlayerInput>()
                .AsSingle();

            Container.Bind<Border>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<Camera>()
               .FromComponentInHierarchy()
               .AsSingle();
            
            Container.Bind<BulletFactory>()
                .AsSingle();
        }
    }
}