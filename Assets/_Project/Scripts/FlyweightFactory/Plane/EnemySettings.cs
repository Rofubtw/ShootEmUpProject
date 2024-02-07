using System.Collections.Generic;
using RofoLib;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy Settings")]
    public class EnemySettings : FlyweightSettings
    {
        public WeaponStrategy enemyWeapon;
        public float speed;
        
        public List<SplineContainer> splines;
        
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;
        
            var flyweight = go.GetOrAdd<EnemyPlane>();
            flyweight.settings = this;
            
            var spline = splines[Random.Range(0, splines.Count)];
            
            var splineAnimate = flyweight.gameObject.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            
            var enemyWeapon = flyweight.gameObject.GetOrAdd<EnemyWeapon>();
            enemyWeapon.SetWeaponStrategy(this.enemyWeapon);

            flyweight.transform.position = spline.EvaluatePosition(0f);
            return flyweight;
        }
        public void SetSplineContainer(SplineContainer spline)
        {
            splines.Add(spline);
        }
    }
}