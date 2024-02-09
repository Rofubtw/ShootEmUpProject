using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/FlashProjectile Settings")]
    public class FlashProjectileSettings : FlyweightSettings
    {
        public float projectileLifeTime = 0.2f;
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;
    
            var flyweight = go.GetOrAdd<FlashProjectile>();
            flyweight.settings = this;
    
            return flyweight;
        }
    }
}