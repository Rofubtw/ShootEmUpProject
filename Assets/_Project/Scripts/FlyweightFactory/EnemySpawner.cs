using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemySettings> enemySettings;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;
        
        float spawnTimer;
        int enemiesInScene;

        void OnEnable()
        {
            foreach (var enemySetting in enemySettings)
            {
                foreach (var spline in gameObject.GetComponentsInChildren<SplineContainer>())
                {
                    enemySetting.SetSplineContainer(spline);
                }
            }
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;
            
            if (enemiesInScene < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void OnDestroy()
        {
            foreach (var enemySetting in enemySettings)
            {
                enemySetting.splines.Clear();
            }
        }

        void SpawnEnemy()
        {  
            var enemySetting = enemySettings[Random.Range(0, enemySettings.Count)];
            var enemy = FlyweightFactory.Spawn(enemySetting);

            enemy.gameObject.TryGetComponent(out SplineAnimate splineAnimate);
            splineAnimate.Restart(true);
            
            enemy.IsAlive = true;
            enemiesInScene++;
        }
        
        public void ReduceEnemyNumber(int number)
        {
            enemiesInScene -= number;
        }
    }
}