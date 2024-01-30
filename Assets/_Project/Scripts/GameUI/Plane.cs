using UnityEngine;

namespace ShootEmUp
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        public float HealthNormalized => health / (float) maxHealth;
        
        int health;
        
        protected virtual void Awake() => health = maxHealth;

        public void SetMaxHealth(int amount) => maxHealth = amount;

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        

        protected abstract void Die();
    }
}