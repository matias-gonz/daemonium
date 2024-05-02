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
    public float minSpawnRate = 0f;
    public Vector2 spawnArea = new(0, 4);
    public GameObject father;

    private void Start()
    {
        StartCoroutine(Spawner());
    }
    
    private IEnumerator Spawner()
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
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
                    var entity = Instantiate(entities[i], spawnPosition, entities[i].transform.rotation);
                    if (father)
                    {
                        entity.transform.parent = father.transform;
                    }
                    break;
                }
            }
        }
    }

}
