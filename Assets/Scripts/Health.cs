using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Bullet
{
    private PointManager pointManager;

    //public HealthBar hBar;
    public float health;
    public float maxHealth = 1500;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Bonsai")
        {
            health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();
        health -= amount;
        //hBar.UpdateHealthBar();
        if(health <= 0)
        {
            Destroy(gameObject);
            pointManager.AddPoints();
        }
    }
    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<Health>();
        if (atm != null)
        {
            atm.TakeDamage(damage);
        }

    }
}
