using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemyPrefabs;
    private bool enableSpawn = true;
    private float xRand;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(15f, 45f);
        
        
        StartCoroutine(Spawn(spawnRate));
        StartCoroutine(SpawnIncrease());
    }

    
    private IEnumerator Spawn(float spawnRate)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (enableSpawn  )
        {
            yield return wait;
            //float xRand = Random.Range(-10, 10);
            //spawnPosition = new Vector3(xRand, transform.position.y, transform.position.z);
            int rand = Random.Range(0, enemyPrefabs.Length);
            
            GameObject spawnedEnemy = enemyPrefabs[rand];
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            
        }
    }
    IEnumerator SpawnIncrease()
    {
        while (enableSpawn)
        {
            yield return new WaitForSeconds(30);
            IncrementSpawnRate();
        }
    }
    void IncrementSpawnRate()
    {
        if (spawnRate >= 0.2)
        {
            StopCoroutine(Spawn(spawnRate));
            spawnRate -= 0.15f;
            StartCoroutine(Spawn(spawnRate));
        }
    }
}
