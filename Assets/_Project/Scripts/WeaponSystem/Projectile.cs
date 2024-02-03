using System;
using System.Collections.Generic;
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
            // Instantiate hit effect
             var hit = FlyweightFactory.Spawn(settings.hitSettings);
             var contact = collision.contacts[0];
             hit.gameObject.transform.position = contact.point;
             isAlive = false;
            
            // If hit a plane, damage it
            if (collision.gameObject.TryGetComponent(out Plane plane))
            {
                plane.TakeDamage(10);
            }
            
            FlyweightFactory.ReturnToPool(this);
        }

        public IEnumerator<float> DestroyEffectCoroutine(float time)
        {
            yield return Timing.WaitForSeconds(time);
            if (isAlive)
            {
                //Instantiate(destroyPrefab, transform.position, Quaternion.identity);
                isAlive = false;
            }
        }
    }
}
