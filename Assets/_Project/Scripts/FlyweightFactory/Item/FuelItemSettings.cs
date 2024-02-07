using RofoLib;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Flyweight/Fuel Item Settings")]
    public class FuelItemSettings : ItemSettings
    { 
        public override Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;
        
            var flyweight = go.GetOrAdd<FuelItem>();
            flyweight.settings = this;
        
            return flyweight;
        }
    }
}