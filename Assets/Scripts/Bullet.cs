using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 8f;
    public int bulletDmg = 25;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
<<<<<<< Updated upstream
=======
        Object.Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
>>>>>>> Stashed changes
    }
}
