using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public List<Enemy> spawnList = new List<Enemy>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private int currentWave;
    private int waveValue;
    public Transform spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer < 0)
        {
            if(spawnedEnemies.Count > 0)
            {
                Instantiate(spawnedEnemies[0], spawnLocation.position, Quaternion.identity); // Spawn first enemy in list
                spawnedEnemies.RemoveAt(0); // Remove spawned enemy from list
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();
        spawnInterval = waveDuration / spawnedEnemies.Count; // Fixed time between each enemy spawn
        waveTimer = waveDuration;
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randEnemyId = Random.Range(0, spawnList.Count);
            int randEnemyCost = spawnList[randEnemyId].cost;
            if(waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(spawnList[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue<=0)
            {
                break;
            }
        }
        
        spawnedEnemies = generatedEnemies;
    }
}
[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
