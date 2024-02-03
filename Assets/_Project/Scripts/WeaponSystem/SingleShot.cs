using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategies/SingleShot", fileName = "SingleShot", order = 0)]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = FlyweightFactory.Spawn(projectileSettings);
            var flashProjectile = FlyweightFactory.Spawn(projectileSettings.flashSettings);
            
            projectile.transform.position = firePoint.position;
            flashProjectile.transform.position = firePoint.position;
            
            projectile.transform.rotation = firePoint.rotation;
            flashProjectile.transform.rotation = firePoint.rotation;
            
            projectile.transform.SetParent(firePoint);
            flashProjectile.transform.SetParent(firePoint);
            
            projectile.gameObject.layer = layer;
        }
    }
}