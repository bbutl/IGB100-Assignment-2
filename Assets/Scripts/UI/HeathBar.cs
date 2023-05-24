using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public GameObject bonsai;
    public Image hbar;
    // Start is called before the first frame update
    float bHealth;
    float bHealthMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bHealth = bonsai.GetComponent<Health>().health;
        bHealthMax = bonsai.GetComponent<Health>().maxHealth;

        hbar.fillAmount = bHealth / bHealthMax;
    }
}
