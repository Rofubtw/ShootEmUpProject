using System.Collections.Generic;
using MEC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] ItemSettings[] itemSettings;
        [SerializeField] float spawnInterval = 10f;
        
        [SerializeField] float minX = -4.5f;
        [SerializeField] float maxX = 4.5f;
        [SerializeField] float posY = 6f;

        CoroutineHandle spawnCoroutine;
        
        
        void Start() => spawnCoroutine = Timing.RunCoroutine(SpawnItemsCoroutine());

        void OnDestroy()
        {
            Timing.KillCoroutines(spawnCoroutine);
        }

        IEnumerator<float> SpawnItemsCoroutine()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                SpawnItems(RandomPosition());
            }
        }

        public void SpawnItems(Vector3 spawnPosition)
        {
            var item = FlyweightFactory.Spawn(itemSettings[Random.Range(0, itemSettings.Length)]);
            item.transform.position = spawnPosition;
        }
        
        Vector3 RandomPosition()
        {
            var randomPosition = new Vector3(Random.Range(minX, maxX),
                transform.position.y + posY, 0f);

            return randomPosition;
        }
    }
}