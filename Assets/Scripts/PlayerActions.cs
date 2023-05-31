using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float fireRate = .5f;
    private float nextShot = -1f;
    private bool canShoot = true;
    
    private PointManager pointManager;

    public GameObject[] prefab;



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
        var input = Input.inputString;
        Vector3 down = new Vector3(0, -1.25f, 0);
        if (CollideTag() != "Ground")
        {
            return;
        }
        else
        {
            switch (input)
            {

                // Instantiate Regular Totem
                case "1":
                    if (pointManager.points >= 50)
                    {
                        pointManager.points -= 50;
                        Instantiate(prefab[0], MousePos() + Vector3.up, Quaternion.identity);
                    }
                    break;
                // Instantiate Slowing Totem
                case "2":
                    if (pointManager.points >= 100)
                    {
                        pointManager.points -= 100;
                        Instantiate(prefab[1], MousePos() + (Vector3.down * 0.5f), Quaternion.identity);

                    }
                    break;
                // Instantiate Healing Totem
                case "3":
                    if (pointManager.points >= 25)
                    {
                        pointManager.points -= 25;
                        Instantiate(prefab[2], MousePos() + (Vector3.up * 0.6f), Quaternion.identity);
                    }
                    break;
                // Instantiate Poison Totem
                case "4":
                    if (pointManager.points >= 5)
                    {
                        pointManager.points -= 5;
                        Instantiate(prefab[3], MousePos() + (Vector3.up * 0.6f), Quaternion.identity);
                    }
                    break;
            }
        }
    }
    public Vector3 MousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hitInfo;
        Vector3 v = new Vector3();
        if (Physics.Raycast(ray, out hitInfo))
        {
            
            v = hitInfo.point;
            
            
        }
        return v;
    }
    private string CollideTag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string c;
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            c = hitInfo.collider.tag;
            return c;
        }
       return null;
        }
}
