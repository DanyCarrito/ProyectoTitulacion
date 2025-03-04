using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTgt : MonoBehaviour
{
    public float spawnRangeX = 10f;
    public float spawnRangeY = 4.5f;
    public GameObject objectToSpawn;

    public void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
