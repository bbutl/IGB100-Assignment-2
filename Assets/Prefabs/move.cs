using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class move : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(transform.forward);
    }
}
