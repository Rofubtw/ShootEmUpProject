using System;
using UnityEngine;

namespace ShootEmUp
{
    public class FuelItem : Item
    {
        new FuelItemSettings settings => (FuelItemSettings) base.settings;
        void OnEnable()
        {
            StartCoroutine(DespawnAfterDelay(settings.itemLifeTime, this));
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.AddFuel((int) settings.amount);
                Destroy(gameObject);
            }
        }
    }
}