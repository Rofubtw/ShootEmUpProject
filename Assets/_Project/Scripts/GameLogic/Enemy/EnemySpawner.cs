using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemeyFactory;

        float spawnTimer;
        int enemiesInScene;

        void OnValidate()
        {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        void Start() => enemeyFactory = new EnemyFactory();

        void Update()
        {
            spawnTimer += Time.deltaTime;

            if (enemiesInScene < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
        void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];
                
            // TODO: Possible optimization - pool enemies
            GameObject enemy = enemeyFactory.CreateEnemy(enemyType, spline);

            enemiesInScene++;
        }

        public void ReduceEnemyNumber(int number)
        {
            enemiesInScene -= number;
        }
    }
}