using System;
using System.Collections.Generic;
using System.Linq;
using MEC;
using UnityEngine;

namespace ShootEmUp
{
    public class Projectile : Flyweight
    {
        new ProjectileSettings settings => (ProjectileSettings) base.settings;
        
        public Action Callback;

        void OnEnable()
        {
            IsAlive = true;
            StartCoroutine(DespawnAfterDelay(settings.projectileLifeTime, this));
        }

        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (settings.projectileSpeed * Time.deltaTime);
            
            Callback?.Invoke();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!IsAlive) return;
            // Instantiate hit effect
             var hit = FlyweightFactory.Spawn(settings.settings.ElementAt(1)); // Hit settings
             var contact = collision.contacts[0];
             hit.gameObject.transform.position = contact.point;
             IsAlive = false;
            
            // If hit a plane, damage it
            if (collision.gameObject.TryGetComponent(out Plane plane))
            {
                plane.TakeDamage(settings.damage);
            }
            
            FlyweightFactory.ReturnToPool(this);
        }

        void OnDisable()
        {
            IsAlive = false;
        }
        
        public IEnumerator<float> DestroyEffectCoroutine(float time)
        {
            yield return Timing.WaitForSeconds(time);
            if (IsAlive)
            {
                var destroyEffect = FlyweightFactory.Spawn(settings.settings.ElementAt(2)); // Disable settings
                destroyEffect.transform.position = transform.position;
                IsAlive = false;
            }
        }
    }
}
