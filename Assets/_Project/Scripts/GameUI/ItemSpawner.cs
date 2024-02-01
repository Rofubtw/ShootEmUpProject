using System;
using System.Collections.Generic;
using EventSystem;
using MEC;
using RofoLib;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] int spawnLimit = 5;
        
        [SerializeField] float minX = -4.5f;
        [SerializeField] float maxX = 4.5f;
        [SerializeField] float minY = 20f;
        [SerializeField] float maxY = 50f;

        CoroutineHandle spawnCoroutine;
        int spawnCount;
        
        void Start() => spawnCoroutine = Timing.RunCoroutine(SpawnItemsCoroutine());

        void OnDestroy()
        {
            Timing.KillCoroutines(spawnCoroutine);
        }

        IEnumerator<float> SpawnItemsCoroutine()
        {
            while (spawnCount < spawnLimit)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                SpawnItems(RandomPosition());
                spawnCount++;
            }
        }

        public void SpawnItems(Vector3 spawnPosition)
        {
            var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)],spawnPosition,Quaternion.identity);
        }
        Vector3 RandomPosition()
        {
            var randomPosition = new Vector3(Random.Range(minX, maxX),
                Random.Range(transform.position.y + minY, transform.position.y + maxY), 0f);

            return randomPosition;
        }
    }
}