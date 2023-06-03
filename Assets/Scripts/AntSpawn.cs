using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawn : MonoBehaviour
{
    public GameObject antHill;
    private bool hillPlaced = false;
    public int spawnChance;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnChance = Random.Range(1, 5);
        waitTime = Random.Range(2, 10);        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (spawnChance == 4 && waitTime <= 0 && hillPlaced == false)
        {
            Instantiate(antHill, transform.position, Quaternion.identity);
            hillPlaced = true;
        }
    }
}
