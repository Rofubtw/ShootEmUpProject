using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Health Item Settings")]
    public class HealthItemSettings : ItemSettings
    { 
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;
        
            var flyweight = go.GetOrAdd<HealthItem>();
            flyweight.settings = this;
        
            return flyweight;
        }
    }
}