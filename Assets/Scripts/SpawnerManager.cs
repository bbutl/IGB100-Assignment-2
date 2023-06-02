using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    
    public GameObject[] spawners;
    public GameObject[] DisabledSpawners;
    public float waveTime = 5f;
    int index = 0;
    int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create array of all spawners that are currently not active
        
            spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach(GameObject spawner in spawners)
            {
                WaveSpawn s = spawners[index].GetComponent<WaveSpawn>();
                if (s.isActive == false)
                {
                    DisabledSpawners[i] = spawners[index];
                }
                index++;
            
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waveTime -= Time.deltaTime;
        if (waveTime <= 0)
        {
            int inx = Random.Range(0, (spawners.Length - 1));
            bool setActive = false;
            foreach (GameObject spawner in spawners)
            {
                if (setActive == false)
                {
                    WaveSpawn x = spawners[inx].GetComponent<WaveSpawn>();
                    if (x.isActive == false)
                    {
                        x.isActive = true;
                        setActive = true;
                    }
                    else
                    {
                        setActive = false;
                    }
                }
            }



            
            waveTime = 5f;
        }
    }
}
