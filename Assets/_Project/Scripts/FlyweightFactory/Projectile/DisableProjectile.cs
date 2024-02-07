using System;

namespace ShootEmUp
{
    public class DisableProjectile : Flyweight
    {
        new DisableProjectileSettings settings => (DisableProjectileSettings) base.settings;
        void OnEnable()
        {
            StartCoroutine(DespawnAfterDelay(settings.projectileLifeTime, this));
        }
    }
}