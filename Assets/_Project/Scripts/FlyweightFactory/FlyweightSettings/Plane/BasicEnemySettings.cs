using System;
using System.Collections.Generic;
using RofoLib;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Basic Enemy Settings")]
    public class BasicEnemySettings : EnemySettings
    {
        public override Flyweight Create()
        {
            var pf = prefabs[Random.Range(0, prefabs.Length)];
            var go = Instantiate(pf);
            go.SetActive(false);
            go.name = pf.name;
        
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
    }
}