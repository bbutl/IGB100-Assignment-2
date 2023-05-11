using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float fireRate = .5f;
    private float nextShot = -1f;
    private bool canShoot = true;
    
    private PointManager pointManager;

    public GameObject totemPrefab;



    public Camera playerCamera;
    public GameObject bulletPrefab;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShot)
        {
            canShoot = true ;
        }
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            Fire(); 
        }
       
       Place();
        
    }
    private void Fire()
    {
            canShoot = false;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
            nextShot = Time.time + fireRate;
    }
    private void Place()
    {
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();
        if (Input.GetKeyDown(KeyCode.E) && pointManager.points >= 50)
        {
            pointManager.points -= 50;
            Instantiate(totemPrefab, transform.position + (transform.forward * 2), transform.rotation);
        }
    }
    
}
