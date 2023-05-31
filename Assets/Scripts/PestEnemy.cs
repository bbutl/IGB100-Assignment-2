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
    private float fixedRotation = 0f;
    Transform r;
    private bool treeContact = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        r = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Fix the X rotation to prevent enemies from tilting upwards
        r.eulerAngles = new Vector3 (fixedRotation, r.eulerAngles.y, r.eulerAngles.z);
        //If not already in contact with Bonsai Tree, move towards it
        if (treeContact == false)
        {
            thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, target.transform.position, (speed * Time.deltaTime));
        }
        // Determine which direction to rotate towards
        Vector3 targetDirection = (target.transform.position - transform.position).normalized;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Rotate towards target
        Quaternion newRotation = Quaternion.LookRotation(newDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);
    }
    // On Collision with Bonsai, enemy will deal damage at a set interval based on delay
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Bonsai")
        {
            treeContact = true;
            timer += Time.deltaTime;
            if (timer > delay)
            {
                
                bonsaiHealth.TakeDamage(damage);
                timer -= delay;
            }
            


        }
        else
        {
            treeContact = false;
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