using Zenject;

namespace Bullet_Module.Effects
{
    public sealed class HitEffectPool : MonoMemoryPool<HitEffect>
    {
        protected override void OnCreated(HitEffect item)
        {
            item.Completed += Despawn;
            base.OnCreated(item);
        }

        protected override void OnDestroyed(HitEffect item)
        {
            item.Completed -= Despawn;
            base.OnDestroyed(item);
        }
    }
}