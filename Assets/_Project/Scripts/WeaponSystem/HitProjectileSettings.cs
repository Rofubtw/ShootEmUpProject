using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/HitProjectile Settings")]
    public class HitProjectileSettings : FlyweightSettings
    {
        public float projectileLifeTime = 0.2f;
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.GetOrAdd<HitProjectile>();
            flyweight.settings = this;
    
            return flyweight;
        }
    }
}