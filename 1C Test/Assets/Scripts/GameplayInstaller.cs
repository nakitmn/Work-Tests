using Border_Module;
using Bullet_Module;
using Input_Module;
using UnityEngine;
using Zenject;

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