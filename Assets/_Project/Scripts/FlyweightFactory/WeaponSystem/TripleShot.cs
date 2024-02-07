using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "ScriptableObjects/WeaponStrategies/TripleShot", fileName = "TripleShot", order = 1)]
    public class TripleShot : WeaponStrategy
    {
        [SerializeField] float spreadAngle = 10f;
        
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for (var i = 0; i < 3; i++)
            {
                var projectile = FlyweightFactory.Spawn(projectileSettings);
                var flashProjectile = FlyweightFactory.Spawn(projectileSettings.settings.ElementAt(0)); // Flash settings
                
                projectile.transform.position = firePoint.position;
                flashProjectile.transform.position = firePoint.position;
            
                projectile.transform.rotation = firePoint.rotation;
                flashProjectile.transform.rotation = firePoint.rotation;
                
                projectile.transform.SetParent(firePoint);
                flashProjectile.transform.SetParent(firePoint);
                
                projectile.transform.Rotate(0f, spreadAngle * (i - 1), 0f);
                projectile.gameObject.layer = layer;
            }
        }
    }
}