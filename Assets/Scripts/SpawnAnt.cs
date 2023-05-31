using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnt : MonoBehaviour
{
    public GameObject prefab;
    public float waitTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            waitTime = 15f;
        }
    }
}
