using UnityEngine;

namespace ShootEmUp
{
    public class FuelItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.AddFuel((int) amount);
                Destroy(gameObject);
            }
        }
    }
}