using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Bullet
{
    private PointManager pointManager;
    public float health;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Bonsai")
        {
            health = 1500;
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
