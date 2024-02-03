using EventSystem;
using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : Plane
    {
        [SerializeField] int scoreWorth;
        [SerializeField] GameObject explosionVFXPrefab;
        [SerializeField] IntEventChannel onEnemyDestroyInt;
        [SerializeField] Vector3EventChannel onEnemyDestroyVector3;
        protected override void Die()
        {
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
            
            
            Destroy(gameObject);
        }

        bool RandomInvoke()
        {
            var luckyNumber = Random.Range(0, 2);
            return luckyNumber == 1;
        }
    }
}