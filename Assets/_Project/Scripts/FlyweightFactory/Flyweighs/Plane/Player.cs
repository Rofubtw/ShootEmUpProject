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
        
        public void AddFuel(int amount)
        {
            fuel += amount;
            if (fuel > maxFuel)
            {
                fuel = maxFuel;
            }
        }

        protected override void Die()
        {
            // TODO: Implement Vfx? Freeze Controls?
        }
        
    }
}