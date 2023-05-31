using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimerBar : MonoBehaviour
{
    public GameObject spawner;
    public Image wavebar;
    float wTimer;
    float wTimerMax;
    void Awake() 
    {
        wTimerMax = spawner.GetComponent<WaveSpawn>().waveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        wTimer = spawner.GetComponent<WaveSpawn>().waveTimer;
        // Debug.Log("counting down" + wTimer.ToString());
        // Debug.Log("from" + wTimerMax.ToString());

        wavebar.fillAmount = wTimer / wTimerMax;
        
    }
}
