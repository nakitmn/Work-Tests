using Border_Module;
using Bullet_Module;
using Bullet_Module.Effects;
using Camera_Module;
using Input_Module;
using UI_Module;
using UnityEngine;
using Zenject;

public sealed class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletsContainer;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Transform _effectsContainer;
    
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
        
        Container.Bind<CameraShaker>()
            .FromComponentInHierarchy()
            .AsSingle();
            
        Container.Bind<BulletFactory>()
            .AsSingle();
        
        Container.BindMemoryPool<Bullet,BulletPool>()
            .FromComponentInNewPrefab(_bulletPrefab)
            .UnderTransform(_bulletsContainer)
            .AsCached();
        
        Container.BindMemoryPool<HitEffect,HitEffectPool>()
            .FromComponentInNewPrefab(_hitEffectPrefab)
            .UnderTransform(_effectsContainer)
            .AsCached();
        
        Container.Bind<LevelEndScreen>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<WinScreenShower>()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<LoseScreenShower>()
            .AsSingle();
    }
}