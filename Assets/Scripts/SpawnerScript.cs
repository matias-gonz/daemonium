using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] entities;
    public float[] entitiesSpawnProbabilityDistribution;
    public float maxSpawnRate = 1.5f;
    public Vector2 spawnArea = new(0, 4);

    private void Start()
    {
        StartCoroutine(Spawner());
    }
    
    private IEnumerator Spawner()
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(Random.Range(0f, maxSpawnRate));
            yield return wait;
            
            Vector3 spawnOffset = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x), 
                Random.Range(-spawnArea.y, spawnArea.y),
                0
                );
            
            Vector3 spawnPosition = transform.position + spawnOffset;
            
            float randomValue = Random.Range(0,1f);

            for (int i = 0; i < entitiesSpawnProbabilityDistribution.Length; i++)
            {
                if (randomValue < entitiesSpawnProbabilityDistribution[i])
                {
                    Instantiate(entities[i], spawnPosition, entities[i].transform.rotation);
                    break;
                }
            }
        }
    }

}
