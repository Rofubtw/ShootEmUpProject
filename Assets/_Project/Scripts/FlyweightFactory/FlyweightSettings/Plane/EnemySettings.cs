using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    public abstract class EnemySettings : FlyweightSettings
    {
        public GameObject[] prefabs;
        public WeaponStrategy enemyWeapon;
        public float speed;
        public int score;
        public HitProjectileSettings explosionVFX;
        
        public List<SplineContainer> splines;

        public virtual void SetSplineContainer(SplineContainer spline)
        {
            splines.Add(spline);
        }
    }
}