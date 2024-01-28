using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyType", fileName = "EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}