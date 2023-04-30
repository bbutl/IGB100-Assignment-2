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
    public float delay = 0.2f;
    public float pdelay = 0.05f;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move towards Bonsai Tree
        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, target.transform.position, (speed * Time.deltaTime));
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
        if(collision.gameObject.tag == "Bullet")
        {

            Destroy(collision.gameObject);
            TakeDamage(bulletDmg);
        }
    }
    IEnumerator AttackSpeed()
    {
        yield return new WaitForSeconds(3);
        bonsaiHealth.TakeDamage(damage);
    }
}