using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawn : MonoBehaviour
{
    public GameObject antHill;
    private bool hillPlaced = false;
    public int i;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 11);
        waitTime = Random.Range(2, 20);        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (i == 3 && waitTime <= 0 && hillPlaced == false)
        {
            Instantiate(antHill, transform.position, Quaternion.identity);
            hillPlaced = true;
        }
    }
}
