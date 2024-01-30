using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Player : Plane
    {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;
        
        public float FuelNormalized => fuel / maxFuel;
        
        float fuel;

        void Start() => fuel = maxFuel;

        void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        protected override void Die()
        {
            // TODO: IMPLEMENT
        }
        
    }
}