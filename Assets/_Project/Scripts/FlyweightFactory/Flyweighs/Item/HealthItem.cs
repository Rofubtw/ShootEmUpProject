using UnityEngine;

namespace ShootEmUp
{
    public class HealthItem : Item
    {
        new HealthItemSettings settings => (HealthItemSettings) base.settings;
        void OnEnable()
        {
            StartCoroutine(DespawnAfterDelay(settings.itemLifeTime, this));
            //StartCoroutine(FallingCoroutine(transform, settings.itemLifeTime));
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.AddHealth((int) settings.amount);
                Destroy(gameObject);
            }
        }
    }
}