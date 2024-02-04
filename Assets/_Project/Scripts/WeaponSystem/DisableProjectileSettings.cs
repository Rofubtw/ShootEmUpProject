using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Disable Settings")]
    public class DisableProjectileSettings : FlyweightSettings
    {
        public float projectileLifeTime = 1f;
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.GetOrAdd<DisableProjectile>();
            flyweight.settings = this;

            return flyweight;
        }
    }
}