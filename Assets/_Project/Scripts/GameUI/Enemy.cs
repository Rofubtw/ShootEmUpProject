using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : Plane
    {
        [SerializeField] int scoreWorth;
        protected override void Die()
        {
            GameManager.Instance.AddScore(scoreWorth);
            Destroy(gameObject);
        }
    }
}