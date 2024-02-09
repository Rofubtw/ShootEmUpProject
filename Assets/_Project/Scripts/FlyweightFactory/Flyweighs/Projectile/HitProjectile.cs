using System;
using UnityEngine;

namespace ShootEmUp
{
    public class HitProjectile : Flyweight
    {
        new HitProjectileSettings settings => (HitProjectileSettings)base.settings;
        void OnEnable()
        {
            StartCoroutine(DespawnAfterDelay(settings.projectileLifeTime, this));
        }
    }
}