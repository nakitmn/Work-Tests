﻿using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>()
                .AsSingle();
        }
    }
}