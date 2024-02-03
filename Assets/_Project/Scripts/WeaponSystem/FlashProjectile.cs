using System;
using UnityEngine;

namespace ShootEmUp
{
    public class FlashProjectile : Flyweight
    {
        new FlashProjectileSettings settings => (FlashProjectileSettings)base.settings;

        void OnEnable()
        { 
            StartCoroutine(DespawnAfterDelay(settings.projectileLifeTime, this));
            
        }
        
        void Update()
        {
            transform.SetParent(null);
        }
    }
}