using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTotem : MonoBehaviour
{
    public Health totemHealth;
    public Health bonsaiHealth;
    public WaveSpawn waveSpawn;
    public int healingAmount = 100;
    public int healingMax = 1500;
    public bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        waveSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<WaveSpawn>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Once waveTimer reaches zero, heal the bonsai
        if (waveSpawn.waveTimer < 1 && complete == false && bonsaiHealth.health < healingMax)
        {
            StartCoroutine(Heal());
        }
    }
    public IEnumerator Heal()
    {
        complete = true;

        yield return new WaitForSeconds(30);
        bonsaiHealth.health += healingAmount;
        complete = false;

    }
}
