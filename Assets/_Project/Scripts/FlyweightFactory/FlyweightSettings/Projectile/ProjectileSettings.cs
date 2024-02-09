using System.Collections.Generic;
using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile Settings")]
    public class ProjectileSettings : FlyweightSettings
    {
        public float projectileSpeed = 10f;
        public float projectileLifeTime = 1f;
        public int damage = 10;

        public List<FlyweightSettings> settings;
        
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.GetOrAdd<Projectile>();
            flyweight.settings = this;

            return flyweight;
        }
    }
}