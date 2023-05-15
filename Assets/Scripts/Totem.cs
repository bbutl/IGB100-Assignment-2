using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public float fireRate = 0.5f;
    private float fireCountDown = 0f;
    Vector3 direction;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a target, repeatedly fire based on firerate, otherwise return
        if (target == null)
        {
            return;
        }





        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    // Method that updates the current target based on the enemy that is closest to the totem
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject neareastEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                neareastEnemy = enemy;
            }
        }
        if (neareastEnemy != null && shortestDistance <= range)
        {
            target = neareastEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        TotemBullet bullet = bulletGO.GetComponent<TotemBullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
