using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        Destroy(gameObject, 10f);
>>>>>>> Blake
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(direction.magnitude <=distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void HitTarget()
    {
<<<<<<< HEAD
        Debug.Log("HIT");
=======
       
>>>>>>> Blake
    }
}
