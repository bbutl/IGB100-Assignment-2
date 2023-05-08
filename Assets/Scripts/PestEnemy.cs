using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestEnemy : Health
{

    public Health enemyHealth;
    public Health bonsaiHealth;
    public GameObject thisObject;
    public GameObject target;
    public float speed;
    Rigidbody rb;
    public float slowDuration = -1f;
    private bool isSlowed = false;
    public float delay = 0.2f;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        PestEnemy enemy = GetComponent<PestEnemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move towards Bonsai Tree
        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, target.transform.position, (speed * Time.deltaTime));
        if (Time.time > slowDuration)
        {
            isSlowed = true;
        }
        if (speed < 1.5f)
        {
            speed = 1.5f;
        }
    }
    // On Collision with Bonsai, enemy will deal damage at a set interval based on delay
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Bonsai")
        {

            timer += Time.deltaTime;
            if (timer > delay)
            {

                bonsaiHealth.TakeDamage(damage);
                timer -= delay;
            }



        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        // Take damage when enemy is hit by damaging projectile
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(bulletDmg);
        }
        // Slow enemy when hit by slowing projectile
        if (collision.gameObject.tag == "SlowBullet")
        {
            this.speed = speed - (speed * 0.2f);
        }
        Destroy(collision.gameObject);
    }
}
    
    