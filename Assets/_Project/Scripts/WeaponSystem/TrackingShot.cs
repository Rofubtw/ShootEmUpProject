using System.Linq;
using EventSystem;
using MEC;
using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategies/PlayerTrackingShot", fileName = "PlayerTrackingShot", order = 2)]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField] float trackingSpeed = 1f;

        Transform target;

        public override void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = FlyweightFactory.Spawn(projectileSettings);
            var flashProjectile = FlyweightFactory.Spawn(projectileSettings.settings.ElementAt(0));
            
            projectile.transform.position = firePoint.position;
            flashProjectile.transform.position = firePoint.position;
            
            projectile.transform.rotation = firePoint.rotation;
            flashProjectile.transform.rotation = firePoint.rotation;
            
            projectile.transform.SetParent(firePoint);
            flashProjectile.transform.SetParent(firePoint);
            
            projectile.gameObject.layer = layer;
            
            var firePointZVector = firePoint.position.z;
            projectile.TryGetComponent(out Projectile projectileComponent);
            projectileComponent.Callback = () =>
            {
                // get direction to target with same Z as firePoint
                Vector3 direction = (target.position - projectile.transform.position).With(z: firePointZVector)
                    .normalized;
            
                // rotate forward, with Z as the UP direction
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation,
                    trackingSpeed * Time.deltaTime);
            };
            
            Timing.RunCoroutine(projectileComponent.DestroyEffectCoroutine(projectileSettings.projectileLifeTime - 0.1f));
        }
    }
}