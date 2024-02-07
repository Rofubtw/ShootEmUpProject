using System;
using EventSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class EnemyPlane : Plane
    {
        [SerializeField] int scoreWorth;
        [SerializeField] GameObject explosionVFXPrefab;
        [SerializeField] IntEventChannel onEnemyDestroyInt;
        [SerializeField] Vector3EventChannel onEnemyDestroyVector3;
        
        new EnemySettings settings => (EnemySettings) base.settings;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Projectile projectile))
            {
                TakeDamage(10);
            }
        }

        protected override void Die()
        {
            if (!IsAlive) return;
            
            GameManager.Instance.AddScore(scoreWorth);
            Instantiate(explosionVFXPrefab, transform.position, Quaternion.identity);
            
            var destroyedEnemyNumber = 1;
            // reduces enemy number in enemy spawner
            onEnemyDestroyInt.Invoke(destroyedEnemyNumber);
            if (RandomInvoke())
            {
                // spawns item when an enemy plane dies
                onEnemyDestroyVector3.Invoke(transform.position);
            }
            
            FlyweightFactory.ReturnToPool(this);
            IsAlive = false;
        }

        bool RandomInvoke()
        {
            var luckyNumber = Random.Range(0, 2);
            return luckyNumber == 1;
        }
    }
}