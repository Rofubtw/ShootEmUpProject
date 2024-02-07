using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField] int damage = 10;
        [SerializeField] float fireRate = 0.5f;
        [SerializeField] protected ProjectileSettings projectileSettings;

        public int Damage => damage;
        public float FireRate => fireRate;

        public virtual void Initialize()
        {
            // no-op
        }
        
        public abstract void Fire(Transform firePoint, LayerMask layer);
    }
}