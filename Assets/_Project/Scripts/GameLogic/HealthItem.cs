using UnityEngine;

namespace ShootEmUp
{
    public class HealthItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.AddHealth((int) amount);
                Destroy(gameObject);
            }
        }
    }
}