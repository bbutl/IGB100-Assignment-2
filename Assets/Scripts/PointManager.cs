using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject bonsai;
    public GameObject origin;
    private Vector3 spawn = new Vector3(0.55f, 75f, 0.16f);
    public int points = 50;
    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.FindGameObjectWithTag("Bonsai");
        Instantiate(bonsai, spawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Health bHealth = bonsai.GetComponent<Health>();
        // Game Over 
        if (bHealth.health < 0)
        {
            
        }
    }
    public void AddPoints()
    {
        points += 10;
    }
}
